namespace Pure.AbpPro;

public interface IAbpProExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}