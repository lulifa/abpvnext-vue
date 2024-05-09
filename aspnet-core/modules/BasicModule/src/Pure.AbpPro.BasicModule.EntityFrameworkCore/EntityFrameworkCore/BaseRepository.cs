namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public class BaseRepository<TEntity, TKey> : EfCoreRepository<BasicModuleDbContext, TEntity, TKey>, IBaseRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    public BaseRepository(IDbContextProvider<BasicModuleDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
