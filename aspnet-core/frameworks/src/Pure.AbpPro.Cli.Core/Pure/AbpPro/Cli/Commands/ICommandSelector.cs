namespace Pure.AbpPro.Cli.Core;

public interface ICommandSelector
{
    Type Select(CommandLineArgs commandLineArgs);
}