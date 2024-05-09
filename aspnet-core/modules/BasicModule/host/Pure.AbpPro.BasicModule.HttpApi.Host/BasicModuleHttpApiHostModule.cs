using Microsoft.Extensions.Hosting.Internal;
using Microsoft.IdentityModel.Tokens;
using Polly;
using Pure.AbpPro.BasicModule.MultiTenancy;
using Pure.AbpPro.Shared.Hosting.Microservices;
using Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(BasicModuleApplicationModule),
    typeof(BasicModuleEntityFrameworkCoreModule),
    typeof(BasicModuleHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpProSharedHostingMicroserviceModule)
    )]
public class BasicModuleHttpApiHostModule : AbpModule
{
    private const string DefaultCorsPolicyName = "Default";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        });

        Configure<PermissionManagementOptions>(options =>
        {
            options.IsDynamicPermissionStoreEnabled = true;
        });

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        context.Services.AddSwaggerGen(options =>
            {
                // 文件下载类型
                options.MapType<FileContentResult>(() => new OpenApiSchema() { Type = "file" });

                options.SwaggerDoc("BasicModule", new OpenApiInfo { Title = "BasicModule API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.EnableAnnotations(); // 启用注解
                options.DocumentFilter<HiddenAbpDefaultApiFilter>();
                options.SchemaFilter<EnumSchemaFilter>();
                // 加载所有xml注释，这里会导致swagger加载有点缓慢
                var xmlPaths = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                foreach (var xml in xmlPaths)
                {
                    options.IncludeXmlComments(xml, true);
                }

                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme()
                    {
                        Description = "直接在下框输入JWT生成的Token",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        BearerFormat = "JWT"
                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });

                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Accept-Language",
                    Description = "多语言设置，系统预设语言有zh-Hans、en，默认为zh-Hans",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                                { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
                        },
                        Array.Empty<string>()
                    }
                });
            });

        context.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                // 是否开启签名认证
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:SecurityKey"]))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = currentContext =>
                {
                    var path = currentContext.HttpContext.Request.Path;
                    if (path.StartsWithSegments("/login"))
                    {
                        return Task.CompletedTask;
                    }

                    var accessToken = string.Empty;
                    if (currentContext.HttpContext.Request.Headers.ContainsKey("Authorization"))
                    {
                        accessToken = currentContext.HttpContext.Request.Headers["Authorization"];
                        if (!string.IsNullOrWhiteSpace(accessToken))
                        {
                            accessToken = accessToken.Split(" ").LastOrDefault();
                        }
                    }

                    if (accessToken.IsNullOrWhiteSpace())
                    {
                        accessToken = currentContext.Request.Query["access_token"].FirstOrDefault();
                    }

                    if (accessToken.IsNullOrWhiteSpace())
                    {
                        accessToken = currentContext.Request.Cookies[DefaultCorsPolicyName];
                    }

                    currentContext.Token = accessToken;
                    currentContext.Request.Headers.Remove("Authorization");
                    currentContext.Request.Headers.Append("Authorization", $"Bearer {accessToken}");

                    return Task.CompletedTask;
                }
            };
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/BasicModule/swagger.json", "BasicModule API");
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
