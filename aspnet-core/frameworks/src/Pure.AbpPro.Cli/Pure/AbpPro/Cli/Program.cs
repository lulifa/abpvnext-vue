namespace Pure.AbpPro.Cli;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
            .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
            .MinimumLevel.Override("Volo.Abp.IdentityModel", LogEventLevel.Information)
            .MinimumLevel.Override("Volo.Abp.Cli", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File(Path.Combine(CliPaths.Log, "pure.abp-pro-cli-logs.txt"), rollingInterval: RollingInterval.Day))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();
        using var application = await AbpApplicationFactory.CreateAsync<AbpProCliModule>(
            options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            });
        await application.InitializeAsync();

        await application.ServiceProvider
            .GetRequiredService<CliService>()
            .RunAsync(args);

        await application.ShutdownAsync();

        Log.CloseAndFlush();
    }
}