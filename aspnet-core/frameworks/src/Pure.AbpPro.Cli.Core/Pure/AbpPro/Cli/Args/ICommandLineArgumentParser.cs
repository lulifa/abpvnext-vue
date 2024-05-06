namespace Pure.AbpPro.Cli.Core;

public interface ICommandLineArgumentParser
{
    CommandLineArgs Parse(string[] args);

    CommandLineArgs Parse(string lineText);
}