using Pure.AbpPro.BasicModule;
using Pure.AbpPro.BasicModule.Localization;
using Pure.AbpPro.Core;
using Pure.AbpPro.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProCoreModule),
    typeof(BasicModuleDomainSharedModule)
)]
public class AbpProDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AbpProGlobalFeatureConfigurator.Configure();
        AbpProModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                    .Add<AbpProResource>(AbpProDomainSharedConsts.DefaultCultureName)
                    .AddVirtualJson("/Localization/AbpPro")
                    .AddBaseTypes(typeof(BasicModuleResource))
                    .AddBaseTypes(typeof(AbpTimingResource));

            options.DefaultResourceType = typeof(AbpProResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProDomainSharedConsts.NameSpace, typeof(AbpProResource));
        });
    }
}
