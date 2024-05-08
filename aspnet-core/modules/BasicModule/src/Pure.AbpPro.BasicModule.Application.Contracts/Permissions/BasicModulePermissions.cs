namespace Pure.AbpPro.BasicModule.Permissions;

public class BasicModulePermissions
{
    public const string GroupName = "BasicModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasicModulePermissions));
    }
}
