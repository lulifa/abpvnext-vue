namespace Serilog
{
    public static class SerilogToEsExtensions
    {
        public static void SetSerilogConfiguration(LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            // 默认读取 configuration 中 "Serilog" 节点下的配置
            loggerConfiguration
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails();

            var writeToElasticSearch = configuration.GetValue<bool>("ElasticSearch:Enabled");

            if (writeToElasticSearch)
            {
                var applicationName = "Pure.AbpPro.HttpApi.Host";
                var esUrl = configuration["ElasticSearch:Url"];
                var indexFormat = configuration["ElasticSearch:IndexFormat"];
                var userName = configuration["ElasticSearch:UserName"];
                var password = configuration["ElasticSearch:Password"];

                if (!string.IsNullOrEmpty(esUrl) && !string.IsNullOrEmpty(indexFormat))
                {
                    loggerConfiguration.WriteTo.Elasticsearch(BuildElasticSearchSinkOptions(esUrl, indexFormat, userName, password));
                    loggerConfiguration.Enrich.WithProperty("Application", applicationName);
                }
            }
        }

        // 创建Es连接
        private static ElasticsearchSinkOptions BuildElasticSearchSinkOptions(string url, string indexFormat, string userName, string password)
        {
            var options = new ElasticsearchSinkOptions(new Uri(url))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                IndexFormat = indexFormat
            };

            if (!string.IsNullOrEmpty(userName))
            {
                options.ModifyConnectionSettings = x => x.BasicAuthentication(userName, password);
            }

            return options;
        }
    }
}