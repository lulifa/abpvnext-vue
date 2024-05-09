namespace Pure.AbpPro.BasicModule;

public static class BasicModuleErrorCodes
{
    public const string OrganizationUnitNotExist = BasicModuleConst.NameSpace + ":100001";
    public const string UserLockedOut = BasicModuleConst.NameSpace + ":100002";
    public const string UserOrPasswordMismatch = BasicModuleConst.NameSpace + ":100003";
    public const string UserDisabled = BasicModuleConst.NameSpace + ":100004";
    public const string TenantNotExist = BasicModuleConst.NameSpace + ":100005";
    public const string NotSupportSetConnectionString = BasicModuleConst.NameSpace + ":100006";

    public const string DataDictionaryExist = BasicModuleConst.NameSpace + ":100007";
    public const string DataDictionaryNotExist = BasicModuleConst.NameSpace + ":100008";
    public const string DataDictionaryDetailExist = BasicModuleConst.NameSpace + ":100009";
    public const string DataDictionaryDetailNotExist = BasicModuleConst.NameSpace + ":100010";
}
