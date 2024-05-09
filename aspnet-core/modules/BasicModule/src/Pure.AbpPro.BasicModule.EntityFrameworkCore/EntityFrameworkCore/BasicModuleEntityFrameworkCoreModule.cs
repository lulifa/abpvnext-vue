namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

[DependsOn(
    typeof(BasicModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BasicModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BasicModuleDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
