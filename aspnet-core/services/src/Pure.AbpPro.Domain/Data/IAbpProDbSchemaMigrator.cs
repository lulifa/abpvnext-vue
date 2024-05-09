using System.Threading.Tasks;

namespace Pure.AbpPro.Data;

public interface IAbpProDbSchemaMigrator
{
    Task MigrateAsync();
}
