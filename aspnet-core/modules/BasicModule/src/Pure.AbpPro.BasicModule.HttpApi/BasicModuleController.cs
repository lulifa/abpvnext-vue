namespace Pure.AbpPro.BasicModule;

public abstract class BasicModuleController : AbpControllerBase
{
    protected BasicModuleController()
    {
        LocalizationResource = typeof(BasicModuleResource);
    }
}
