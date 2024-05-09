using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Pure.AbpPro;

[Dependency(ReplaceServices = true)]
public class AbpProBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpPro";
}
