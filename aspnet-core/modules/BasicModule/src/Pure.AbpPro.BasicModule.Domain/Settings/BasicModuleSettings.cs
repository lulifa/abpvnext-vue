namespace Pure.AbpPro.BasicModule.Settings;

public static class BasicModuleSettings
{
    public const string GroupName = "BasicModule";

    /* Add constants for setting names. Example:
     * public const string MySettingName = GroupName + ".MySettingName";
     */

    /// <summary>
    /// 系统控制分组
    /// </summary>
    public static class Group
    {
        public const string Default = "Setting.Group";
        public const string SystemManagement = Default + ".System";
    }
}
