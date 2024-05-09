namespace Pure.AbpPro.BasicModule;

public interface IBaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
}
