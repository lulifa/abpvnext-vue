namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(BasicModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class BasicModuleApplicationContractsModule : AbpModule
{

}
