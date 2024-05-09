namespace Pure.AbpPro;

[DependsOn(
    typeof(AbpProDomainSharedModule),
    typeof(BasicModuleDomainModule),
    typeof(AbpEmailingModule)
)]
public class AbpProDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<AbpProDomainModule>(); });
    }
}
