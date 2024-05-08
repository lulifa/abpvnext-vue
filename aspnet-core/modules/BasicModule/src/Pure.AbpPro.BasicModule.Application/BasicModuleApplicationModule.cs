namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(BasicModuleDomainModule),
    typeof(BasicModuleApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class BasicModuleApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BasicModuleApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BasicModuleApplicationModule>(validate: true);
        });
    }
}
