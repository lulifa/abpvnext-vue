using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

[ConnectionStringName(BasicModuleDbProperties.ConnectionStringName)]
public class BasicModuleDbContext : AbpDbContext<BasicModuleDbContext>, IBasicModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public BasicModuleDbContext(DbContextOptions<BasicModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBasicModule();
    }
}
