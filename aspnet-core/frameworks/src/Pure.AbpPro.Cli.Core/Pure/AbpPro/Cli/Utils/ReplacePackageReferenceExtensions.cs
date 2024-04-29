namespace Pure.AbpPro.Cli.Utils;

public static class ReplacePackageReferenceExtensions
{
    public static string ReplacePackageReferenceCore(this string content)
    {
        return content
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\frameworks\\src\\Pure.AbpPro.Core\\Pure.AbpPro.Core.csproj\"/>",
                    "<PackageReference Include=\"Pure.AbpPro.Core\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\aspnet-core\\frameworks\\src\\Pure.AbpPro.Core\\Pure.AbpPro.Core.csproj\"/>",
                    "<PackageReference Include=\"Pure.AbpPro.Core\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\shared\\Pure.AbpPro.Shared.Hosting.Microservices\\Pure.AbpPro.Shared.Hosting.Microservices.csproj\"/>",
                    "<PackageReference Include=\"Pure.AbpPro.Shared.Hosting.Microservices\"/>")
                .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\shared\\Pure.AbpPro.Shared.Hosting.Gateways\\Pure.AbpPro.Shared.Hosting.Gateways.csproj\"/>",
                    "<PackageReference Include=\"Pure.AbpPro.Shared.Hosting.Gateways\"/>")
            ;
    }

    public static string ReplacePackageReferenceBasicManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.Application\\Pure.AbpPro.BasicManagement.Application.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.Application.Contracts\\Pure.AbpPro.BasicManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.Application.Contracts\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.Domain\\Pure.AbpPro.BasicManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.Domain.Shared\\Pure.AbpPro.BasicManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.EntityFrameworkCore\\Pure.AbpPro.BasicManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.FreeSqlRepository\\Pure.AbpPro.BasicManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FreeSqlRepository\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.HttpApi\\Pure.AbpPro.BasicManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\BasicManagement\\src\\Pure.AbpPro.BasicManagement.HttpApi.Client\\Pure.AbpPro.BasicManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.BasicManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceDataDictionaryManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.Application\\Pure.AbpPro.DataDictionaryManagement.Application.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.Application.Contracts\\Pure.AbpPro.DataDictionaryManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.Domain\\Pure.AbpPro.DataDictionaryManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.Domain.Shared\\Pure.AbpPro.DataDictionaryManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.EntityFrameworkCore\\Pure.AbpPro.DataDictionaryManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.FreeSqlRepository\\Pure.AbpPro.DataDictionaryManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.HttpApi\\Pure.AbpPro.DataDictionaryManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\DataDictionaryManagement\\src\\Pure.AbpPro.DataDictionaryManagement.HttpApi.Client\\Pure.AbpPro.DataDictionaryManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.DataDictionaryManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceFileManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.Application\\Pure.AbpPro.FileManagement.Application.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.Application.Contracts\\Pure.AbpPro.FileManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.Application.Contracts\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.Domain\\Pure.AbpPro.FileManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.Domain.Shared\\Pure.AbpPro.FileManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.EntityFrameworkCore\\Pure.AbpPro.FileManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.FreeSqlRepository\\Pure.AbpPro.FileManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FreeSqlRepository\"/>")
            .Replace("<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.HttpApi\\Pure.AbpPro.FileManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\FileManagement\\src\\Pure.AbpPro.FileManagement.HttpApi.Client\\Pure.AbpPro.FileManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FileManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceLanguageManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.Application\\Pure.AbpPro.LanguageManagement.Application.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.Application.Contracts\\Pure.AbpPro.LanguageManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.Domain\\Pure.AbpPro.LanguageManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.Domain.Shared\\Pure.AbpPro.LanguageManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.EntityFrameworkCore\\Pure.AbpPro.LanguageManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.FreeSqlRepository\\Pure.AbpPro.LanguageManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.HttpApi\\Pure.AbpPro.LanguageManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\LanguageManagement\\src\\Pure.AbpPro.LanguageManagement.HttpApi.Client\\Pure.AbpPro.LanguageManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.LanguageManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePackageReferenceNotificationManagement(this string content)
    {
        return content
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.Application\\Pure.AbpPro.NotificationManagement.Application.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.Application\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.Application.Contracts\\Pure.AbpPro.NotificationManagement.Application.Contracts.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.Application.Contracts\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.Domain\\Pure.AbpPro.NotificationManagement.Domain.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.Domain\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.Domain.Shared\\Pure.AbpPro.NotificationManagement.Domain.Shared.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.Domain.Shared\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.EntityFrameworkCore\\Pure.AbpPro.NotificationManagement.EntityFrameworkCore.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.EntityFrameworkCore\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.FreeSqlRepository\\Pure.AbpPro.NotificationManagement.FreeSqlRepository.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.FreeSqlRepository\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.HttpApi\\Pure.AbpPro.NotificationManagement.HttpApi.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.HttpApi\"/>")
            .Replace(
                "<ProjectReference Include=\"..\\..\\..\\..\\..\\aspnet-core\\modules\\NotificationManagement\\src\\Pure.AbpPro.NotificationManagement.HttpApi.Client\\Pure.AbpPro.NotificationManagement.HttpApi.Client.csproj\"/>",
                "<PackageReference Include=\"Pure.AbpPro.NotificationManagement.HttpApi.Client\"/>");
    }

    public static string ReplacePurePackageVersion(this string context, string version)
    {
        return context.Replace("MyVersion", version);
    }
}