namespace Pure.AbpPro.BasicModule;

public static class BasicModuleDbProperties
{
    public static string DbTablePrefix { get; set; } = "BasicModule";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BasicModule";
}
