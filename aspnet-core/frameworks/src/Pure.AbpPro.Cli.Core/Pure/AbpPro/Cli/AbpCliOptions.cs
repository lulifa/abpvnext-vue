namespace Pure.AbpPro.Cli;

public class AbpCliOptions
{
    public Dictionary<string, Type> Commands { get; }


    /// <summary>
    /// Default value: "pure.abp".
    /// </summary>
    public string ToolName { get; set; } = "pure.abp";

    public AbpCliOptions()
    {
        Commands = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
    }
}