namespace Pure.AbpPro.CAP;

[DependsOn(
    typeof(AbpEventBusModule), 
    typeof(AbpProLocalizationModule),
    typeof(AbpUnitOfWorkModule))]
public class AbpProCapModule : AbpModule
{
}