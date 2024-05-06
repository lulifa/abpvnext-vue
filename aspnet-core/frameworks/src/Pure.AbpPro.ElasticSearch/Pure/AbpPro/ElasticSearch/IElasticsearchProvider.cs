namespace Pure.AbpPro.ElasticSearch;

public interface IElasticsearchProvider
{
    IElasticClient GetClient();
}