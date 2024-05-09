namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public static class DataDictionaryExtension
{
    public static IQueryable<DataDictionary> IncludeDetails(this IQueryable<DataDictionary> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }
        return queryable.Include(item => item.Details);
    }
}
