using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

[ConnectionStringName(BasicModuleDbProperties.ConnectionStringName)]
public interface IBasicModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
