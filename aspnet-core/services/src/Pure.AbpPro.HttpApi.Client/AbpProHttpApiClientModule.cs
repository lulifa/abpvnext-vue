namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProApplicationContractsModule),
    typeof(BasicModuleHttpApiClientModule)
)]
public class AbpProHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AbpProApplicationContractsModule).Assembly,
            RemoteServiceName
        );
    }
}
