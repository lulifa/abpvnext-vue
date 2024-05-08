namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public class BasicModuleHttpApiHostMigrationsDbContext : AbpDbContext<BasicModuleHttpApiHostMigrationsDbContext>
{
    public BasicModuleHttpApiHostMigrationsDbContext(DbContextOptions<BasicModuleHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureBasicModule();
    }
}
