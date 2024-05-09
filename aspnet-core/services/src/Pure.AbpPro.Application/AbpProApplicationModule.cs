using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProDomainModule),
    typeof(AbpProApplicationContractsModule),
    typeof(BasicModuleApplicationModule)
)]
public class AbpProApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AbpProApplicationModule>();
        });
    }
}
