namespace Pure.AbpPro.BasicModule.Permissions;

public class BasicModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BasicModulePermissions.GroupName, L("Permission:BasicModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BasicModuleResource>(name);
    }
}
