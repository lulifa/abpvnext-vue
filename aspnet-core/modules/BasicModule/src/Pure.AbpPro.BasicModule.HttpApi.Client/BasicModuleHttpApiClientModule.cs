namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(BasicModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BasicModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BasicModuleApplicationContractsModule).Assembly,
            BasicModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BasicModuleHttpApiClientModule>();
        });

    }
}
