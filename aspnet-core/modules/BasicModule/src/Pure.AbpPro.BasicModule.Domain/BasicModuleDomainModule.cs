namespace Pure.AbpPro.BasicModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(BasicModuleDomainSharedModule)
)]
public class BasicModuleDomainModule : AbpModule
{

}
