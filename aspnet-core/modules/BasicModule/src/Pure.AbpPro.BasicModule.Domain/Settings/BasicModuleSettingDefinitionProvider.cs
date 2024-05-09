using Pure.AbpPro.BasicModule.Localization;
using Volo.Abp.Identity.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Timing;

namespace Pure.AbpPro.BasicModule.Settings;

public class BasicModuleSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        /* Define module settings here.
         * Use names from BasicModuleSettings class.
         */
    }

    /// <summary>
    /// 重写默认setting添加自定义属性
    /// </summary>
    private static void OverrideDefaultSettings(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(TimingSettingNames.TimeZone,
                    "China Standard Time",
                    L("DisplayName:Abp.Timing.Timezone"),
                    L("Description:Abp.Timing.Timezone"))
                .WithProperty(BasicModuleSettings.Group.Default,
                    BasicModuleSettings.Group.SystemManagement)
                .WithProperty(AbpProSettingConsts.ControlType.Default,
                    AbpProSettingConsts.ControlType.TypeText));

        context.GetOrNull(IdentitySettingNames.Password.RequiredLength)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.Number);

        context.GetOrNull(IdentitySettingNames.Password.RequiredUniqueChars)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.Number);

        context.GetOrNull(IdentitySettingNames.Password.RequireNonAlphanumeric)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.TypeCheckBox);

        context.GetOrNull(IdentitySettingNames.Password.RequireLowercase)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.TypeCheckBox);

        context.GetOrNull(IdentitySettingNames.Password.RequireUppercase)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.TypeCheckBox);

        context.GetOrNull(IdentitySettingNames.Password.RequireDigit)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.TypeCheckBox);

        context.GetOrNull(IdentitySettingNames.Lockout.LockoutDuration)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.Number);

        context.GetOrNull(IdentitySettingNames.Lockout.MaxFailedAccessAttempts)
            .WithProperty(BasicModuleSettings.Group.Default,
                BasicModuleSettings.Group.SystemManagement)
            .WithProperty(AbpProSettingConsts.ControlType.Default,
                AbpProSettingConsts.ControlType.Number);
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BasicModuleResource>(name);
    }
}
