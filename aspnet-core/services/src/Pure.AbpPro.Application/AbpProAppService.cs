using System;
using System.Collections.Generic;
using System.Text;
using Pure.AbpPro.Localization;
using Volo.Abp.Application.Services;

namespace Pure.AbpPro;

/* Inherit your application services from this class.
 */
public abstract class AbpProAppService : ApplicationService
{
    protected AbpProAppService()
    {
        LocalizationResource = typeof(AbpProResource);
    }
}
