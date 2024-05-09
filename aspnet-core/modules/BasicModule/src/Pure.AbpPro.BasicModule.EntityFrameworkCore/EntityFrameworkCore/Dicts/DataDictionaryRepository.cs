using Pure.AbpPro.BasicModule.Dicts;

namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public class DataDictionaryRepository : BaseRepository<DataDictionary, Guid>, IDataDictionaryRepository
{
    public DataDictionaryRepository(IDbContextProvider<BasicModuleDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
