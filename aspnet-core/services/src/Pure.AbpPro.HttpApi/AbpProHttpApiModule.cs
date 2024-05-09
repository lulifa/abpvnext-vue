using Pure.AbpPro.BasicModule;
using Pure.AbpPro.Localization;

namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProApplicationContractsModule),
    typeof(BasicModuleHttpApiModule)
    )]
public class AbpProHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpProResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
