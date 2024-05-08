namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public class BasicModuleHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BasicModuleHttpApiHostMigrationsDbContext>
{
    public BasicModuleHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BasicModuleHttpApiHostMigrationsDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);

        return new BasicModuleHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
