using Pure.AbpPro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Pure.AbpPro.Permissions;

public class AbpProPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }
}
