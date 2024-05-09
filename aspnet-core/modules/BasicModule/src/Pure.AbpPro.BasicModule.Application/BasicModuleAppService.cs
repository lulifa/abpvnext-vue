using Pure.AbpPro.BasicModule.Localization;

namespace Pure.AbpPro.BasicModule;

public abstract class BasicModuleAppService : ApplicationService
{
    protected BasicModuleAppService()
    {
        LocalizationResource = typeof(BasicModuleResource);
        ObjectMapperContext = typeof(BasicModuleApplicationModule);
    }
}
