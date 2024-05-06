namespace Pure.AbpPro.Cli.Core;

public interface IConsoleCommand
{
    Task ExecuteAsync(CommandLineArgs commandLineArgs);

    void GetUsageInfo();

    string GetShortDescription();
}