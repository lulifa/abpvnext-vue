namespace Pure.AbpPro.CAP.EntityFrameworkCore;

public static class AbpProCapOptionsExtensions
{
    public static CapOptions SetCapDbConnectionString(this CapOptions options, string dbConnectionString)
    {
        options.RegisterExtension(new AbpProEfCoreDbContextCapOptionsExtension
        {
            CapUsingDbConnectionString = dbConnectionString
        });

        return options;
    }
}

