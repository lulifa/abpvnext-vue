namespace Pure.AbpPro.Cli;

[DependsOn(
    typeof(AbpDddDomainModule)
)]
public class AbpProCliCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpCliOptions>(options => { options.Commands[HelpCommand.Name] = typeof(HelpCommand); });
        Configure<AbpCliOptions>(options => { options.Commands[NewCommand.Name] = typeof(NewCommand); });

        Configure<AbpProCliOptions>(options =>
        {
            options.Owner = "lulifa";
            options.RepositoryId = "abp-vnext-pro-vue";
            options.Token = "abp-vnext-pro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abp-vnext-pro";
            options.Templates = new List<AbpProTemplateOptions>()
            {
                new AbpProTemplateOptions("abp-vnext-pro-vue", "pro", "源码版本", true)
                {
                    ExcludeFiles = "templates,docs,.github,LICENSE,Readme.md",
                    ReplaceSuffix = ".sln,.csproj,.cs,.cshtml,.json,.ci,.yml,.yaml,.nswag,.DotSettings,.env,Directory.Build.Pure.targets",
                    OldCompanyName = "Pure",
                    OldProjectName = "AbpPro"
                },
                new AbpProTemplateOptions("abp-vnext-pro-vue-nuget-all", "pro.all", "Nuget完整版本")
                {
                    //ExcludeFiles = "aspnet-core,vben28,abp-vnext-pro-nuget-module,abp-vnext-pro-nuget-simplify,docs,.github,LICENSE,Readme.md",
                    ReplaceSuffix = ".sln,.csproj,.cs,.cshtml,.json,.ci,.yml,.yaml,.nswag,.DotSettings,.env,Directory.Build.Pure.targets",
                    OldCompanyName = "MyCompanyName",
                    OldProjectName = "MyProjectName"
                },
                new AbpProTemplateOptions("abp-vnext-pro-vue-nuget-simplify", "pro.simplify", "Nuget简单版本")
                {
                    //ExcludeFiles = "aspnet-core,vben28,abp-vnext-pro-nuget-module,abp-vnext-pro-nuget-all,docs,.github,LICENSE,Readme.md",
                    ReplaceSuffix = ".sln,.csproj,.cs,.cshtml,.json,.ci,.yml,.yaml,.nswag,.DotSettings,.env,Directory.Build.Pure.targets",
                    OldCompanyName = "MyCompanyName",
                    OldProjectName = "MyProjectName"
                },

                new AbpProTemplateOptions("abp-vnext-pro-vue-nuget-module", "pro.module", "模块")
                {
                    //ExcludeFiles = "aspnet-core,vben28,abp-vnext-pro-nuget-all,abp-vnext-pro-nuget-simplify,docs,.github,LICENSE,Readme.md",
                    ReplaceSuffix = ".sln,.csproj,.cs,.cshtml,.json,.ci,.yml,.yaml,.nswag,.DotSettings,.env,Directory.Build.Pure.targets",
                    OldCompanyName = "MyCompanyName",
                    OldProjectName = "MyProjectName",
                    OldModuleName = "MyModuleName",
                },
            };
        });

        context.Services.AddHttpClient();
    }
}