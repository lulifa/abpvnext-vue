namespace Pure.AbpPro.BasicModule;

public static class BasicModuleErrorCodes
{
    public const string OrganizationUnitNotExist = BasicModuleConst.NameSpace + ":100001";
    public const string UserLockedOut = BasicModuleConst.NameSpace + ":100002";
    public const string UserOrPasswordMismatch = BasicModuleConst.NameSpace + ":100003";
    public const string UserDisabled = BasicModuleConst.NameSpace + ":100004";
    public const string TenantNotExist = BasicModuleConst.NameSpace + ":100005";
    public const string NotSupportSetConnectionString = BasicModuleConst.NameSpace + ":100006";
}
