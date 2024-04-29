namespace Pure.AbpPro.Cli;

[DependsOn(
    typeof(AbpProCliCoreModule),
    typeof(AbpAutofacModule)
)]
public class AbpProCliModule : AbpModule
{
}
