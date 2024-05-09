using Pure.AbpPro.BasicModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Pure.AbpPro.BasicModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Pure.AbpPro.BasicModule.Permissions;

public class BasicModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var abpIdentityGroup = context.GetGroup(IdentityPermissions.GroupName);
        var userManagement = abpIdentityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
        userManagement.AddChild(BasicModulePermissions.SystemManagement.UserEnable, L("Permission:Enable"), multiTenancySide: MultiTenancySides.Both);
        userManagement.AddChild(BasicModulePermissions.SystemManagement.UserExport, L("Permission:Export"), multiTenancySide: MultiTenancySides.Both);

        abpIdentityGroup.AddPermission(BasicModulePermissions.SystemManagement.AuditLog, L("Permission:AuditLogManagement"), multiTenancySide: MultiTenancySides.Both);
        abpIdentityGroup.AddPermission(BasicModulePermissions.SystemManagement.Setting, L("Permission:SettingManagement"), multiTenancySide: MultiTenancySides.Both);
        abpIdentityGroup.AddPermission(BasicModulePermissions.SystemManagement.IdentitySecurityLog, L("Permission:IdentitySecurityLog"), multiTenancySide: MultiTenancySides.Both);
        abpIdentityGroup.AddPermission(BasicModulePermissions.SystemManagement.FeatureManagement, L("Permission:FeatureManagement"), multiTenancySide: MultiTenancySides.Both);
        
        var organizationUnitManagement = abpIdentityGroup
            .AddPermission(BasicModulePermissions.SystemManagement.OrganizationUnit, L("Permission:OrganizationUnitManagement"), multiTenancySide: MultiTenancySides.Both);

        organizationUnitManagement.AddChild
        (
            BasicModulePermissions.SystemManagement.OrganizationUnitManagement.Create,
            L("Permission:Create"), multiTenancySide: MultiTenancySides.Both
        );
        organizationUnitManagement.AddChild
        (
            BasicModulePermissions.SystemManagement.OrganizationUnitManagement.Update,
            L("Permission:Update"), multiTenancySide: MultiTenancySides.Both
        );
        organizationUnitManagement.AddChild
        (
            BasicModulePermissions.SystemManagement.OrganizationUnitManagement.Delete,
            L("Permission:Delete"), multiTenancySide: MultiTenancySides.Both
        );
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BasicModuleResource>(name);
    }
}