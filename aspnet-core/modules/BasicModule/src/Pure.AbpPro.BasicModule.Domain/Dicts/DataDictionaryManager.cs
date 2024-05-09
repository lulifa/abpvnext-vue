namespace Pure.AbpPro.BasicModule.Dicts;

public class DataDictionaryManager : DomainService, IDataDictionaryManager
{
    private readonly IRepository<DataDictionary, Guid> repository;

    public DataDictionaryManager(IRepository<DataDictionary,Guid> repository)
    {
        this.repository = repository;

    }

}