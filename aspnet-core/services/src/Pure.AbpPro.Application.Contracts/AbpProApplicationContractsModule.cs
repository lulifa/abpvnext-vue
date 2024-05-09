using Pure.AbpPro.BasicModule;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(BasicModuleApplicationContractsModule)
)]
public class AbpProApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AbpProDtoExtensions.Configure();
    }
}
