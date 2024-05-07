namespace Pure.AbpPro.Shared.Hosting.Microservices;

public static class ApplicationBuilderExtensions
{
    public static string UseConsul(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var configuration = scope.ServiceProvider.GetService<IConfiguration>();

        if (!configuration.GetValue<bool>("Consul:Enabled"))
            return string.Empty;

        string serviceName = configuration.GetValue<string>("Consul:Service");
        Uri appUrl = new(configuration.GetValue<string>("App:SelfUrl"));

        var client = scope.ServiceProvider.GetService<IConsulClient>();

        var consulServiceRegistration = new AgentServiceRegistration
        {
            Name = serviceName,
            ID = $"{serviceName}:{Guid.NewGuid()}",
            Address = appUrl.Host,
            Port = appUrl.Port,
            Check = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(3),
                HTTP = $"{appUrl}/health",
                Timeout = TimeSpan.FromSeconds(15)
            }
        };

        client.Agent.ServiceRegister(consulServiceRegistration);
        app.ApplicationServices.GetService<IHostApplicationLifetime>().ApplicationStopping
            .Register(() => client.Agent.ServiceDeregister(consulServiceRegistration.ID));

        return consulServiceRegistration.ID;
    }

    /// <summary>
    /// 多语言中间件
    /// <remarks>浏览器传递的请求头：Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6而abp框架中简体中文为：zh-Hans</remarks>
    /// <example>
    /// app.UseAbpProRequestLocalization();
    /// </example>
    /// </summary>
    public static IApplicationBuilder UseAbpProRequestLocalization(this IApplicationBuilder app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        return app.UseAbpRequestLocalization(options =>
        {
            // 移除自带header解析器
            options.RequestCultureProviders.RemoveAll(provider => provider is AcceptLanguageHeaderRequestCultureProvider);
            // 添加header解析器
            options.RequestCultureProviders.Add(new AbpProAcceptLanguageHeaderRequestCultureProvider());
        });
    }
}