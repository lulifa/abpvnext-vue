using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Pure.AbpPro.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public interface IAbpProDbContext : IEfCoreDbContext
    {

    }
}
