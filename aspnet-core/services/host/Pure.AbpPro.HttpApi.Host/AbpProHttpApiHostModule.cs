using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Pure.AbpPro.CAP;
using Pure.AbpPro.CAP.EntityFrameworkCore;
using Pure.AbpPro.EntityFrameworkCore;
using Pure.AbpPro.Shared.Hosting.Microservices;
using Savorboard.CAP.InMemoryMessageQueue;
using Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Auditing;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Auditing;
using Volo.Abp.Security.Claims;
using Volo.Abp.VirtualFileSystem;

namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProHttpApiModule),
        typeof(AbpProSharedHostingMicroserviceModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(AbpProEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAccountWebModule),
        typeof(AbpProApplicationModule),
        typeof(AbpProCapModule),
        typeof(AbpProCapEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpCachingStackExchangeRedisModule)
//typeof(AbpBackgroundJobsHangfireModule)
)]
public class AbpProHttpApiHostModule : AbpModule
{
    private const string DefaultCorsPolicyName = "Default";
    public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
    {
        base.OnPostApplicationInitialization(context);
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureConventionalControllers();


        ConfigureCache(configuration);
        ConfigureAuthentication(context, configuration);
        ConfigureSwaggerServices(context);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureCors(context, configuration);
        ConfigureMiniProfiler(context);
        ConfigureIdentity(context);
        ConfigurationSignalR(context);
        ConfigureCap(context);
        ConfigureAuditLog(context);
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "AbpPro:"; });
    }

    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AbpProApplicationModule).Assembly);
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
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

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context)
    {
        context.Services.AddSwaggerGen(options =>
        {
            // 文件下载类型
            options.MapType<FileContentResult>(() => new OpenApiSchema() { Type = "file" });

            options.SwaggerDoc("AbpPro", new OpenApiInfo { Title = "AbpPro API", Version = "v1" });
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
    }

    /// <summary>
    /// 配置MiniProfiler
    /// </summary>
    private void ConfigureMiniProfiler(ServiceConfigurationContext context)
    {
        if (context.Services.GetConfiguration().GetValue("MiniProfiler:Enabled", false))
        {
            context.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();
        }
    }

    /// <summary>
    /// 配置Identity
    /// </summary>
    private void ConfigureIdentity(ServiceConfigurationContext context)
    {
        context.Services.Configure<IdentityOptions>(options => { options.Lockout = new LockoutOptions() { AllowedForNewUsers = false }; });
    }

    private void ConfigurationSignalR(ServiceConfigurationContext context)
    {
        //context.Services
        //    .AddSignalR()
        //    .AddStackExchangeRedis(context.Services.GetConfiguration().GetValue<string>("Redis:Configuration"),
        //        options => { options.Configuration.ChannelPrefix = "Pure.AbpPro"; });
    }

    private void ConfigureCap(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var enabled = configuration.GetValue("Cap:Enabled", false);
        if (enabled)
        {
            context.AddAbpCap(capOptions =>
            {
                capOptions.SetCapDbConnectionString(configuration["ConnectionStrings:Default"]);
                capOptions.UseEntityFramework<AbpProDbContext>();
                capOptions.UseRabbitMQ(option =>
                {
                    option.HostName = configuration.GetValue<string>("Cap:RabbitMq:HostName");
                    option.UserName = configuration.GetValue<string>("Cap:RabbitMq:UserName");
                    option.Password = configuration.GetValue<string>("Cap:RabbitMq:Password");
                    option.Port = configuration.GetValue<int>("Cap:RabbitMq:Port");
                });

                var hostingEnvironment = context.Services.GetHostingEnvironment();
                capOptions.UseDashboard(options =>
                {
                    options.AuthorizationPolicy = AbpProCapPermissions.CapManagement.Cap;
                });
            });
        }
        else
        {
            context.AddAbpCap(capOptions =>
            {
                capOptions.UseInMemoryStorage();
                capOptions.UseInMemoryMessageQueue();
                var hostingEnvironment = context.Services.GetHostingEnvironment();
                var auth = !hostingEnvironment.IsDevelopment();
                capOptions.UseDashboard();
            });
        }
    }

    /// <summary>
    /// 审计日志
    /// </summary>
    private void ConfigureAuditLog(ServiceConfigurationContext context)
    {
        Configure<AbpAuditingOptions>
        (
            options =>
            {
                options.IsEnabled = true;
                options.EntityHistorySelectors.AddAllEntities();
                options.ApplicationName = "Pure.AbpPro";
            }
        );

        Configure<AbpAspNetCoreAuditingOptions>(
            options =>
            {
                options.IgnoredUrls.Add("/AuditLogs/page");
                options.IgnoredUrls.Add("/hangfire/stats");
                options.IgnoredUrls.Add("/hangfire/recurring/trigger");
                options.IgnoredUrls.Add("/cap");
                options.IgnoredUrls.Add("/");
            });
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("AbpPro");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "AbpPro-Protection-Keys");
        }
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(configuration["App:CorsOrigins"]?
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray() ?? Array.Empty<string>())
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.GetConfiguration();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();
        app.UseCorrelationId();
        app.UseStaticFiles();
        if (configuration.GetValue("MiniProfiler:Enabled", false))
        {
            app.UseMiniProfiler();
        }
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/AbpPro/swagger.json", "AbpPro API");
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints(endpoints => { endpoints.MapHealthChecks("/health"); });
        // app.UseHangfireDashboard("/hangfire", new DashboardOptions()
        // {
        //     Authorization = new[] { new CustomHangfireAuthorizeFilter() },
        //     IgnoreAntiforgeryToken = true
        // });

        if (configuration.GetValue("Consul:Enabled", false))
        {
            app.UseConsul();
        }
    }
}
