namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(BasicModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BasicModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BasicModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BasicModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
