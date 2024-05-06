namespace Pure.AbpPro.Localization;

public interface IAbpProExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}