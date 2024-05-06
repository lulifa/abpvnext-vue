namespace Pure.AbpPro.ElasticSearch;

[DependsOn(typeof(AbpAutofacModule))]
public class AbpProElasticSearchModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        context.Services.Configure<AbpProElasticSearchOptions>(configuration.GetSection("ElasticSearch"));
    }
}