using Pure.AbpPro.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace Pure.AbpPro.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpProEntityFrameworkCoreModule),
    typeof(AbpProApplicationContractsModule)
    )]
public class AbpProDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
