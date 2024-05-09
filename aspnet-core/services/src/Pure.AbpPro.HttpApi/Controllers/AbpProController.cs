using Pure.AbpPro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Pure.AbpPro.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpProController : AbpControllerBase
{
    protected AbpProController()
    {
        LocalizationResource = typeof(AbpProResource);
    }
}
