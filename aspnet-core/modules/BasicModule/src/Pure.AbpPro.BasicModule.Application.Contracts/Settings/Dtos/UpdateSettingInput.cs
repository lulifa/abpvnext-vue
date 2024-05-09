namespace Pure.AbpPro.BasicModule.Settings.Dtos
{
    public class UpdateSettingInput
    {
        public Dictionary<string, string> Values { get; set; }

        public UpdateSettingInput()
        {
            Values = new Dictionary<string, string>();
        }
    }
}