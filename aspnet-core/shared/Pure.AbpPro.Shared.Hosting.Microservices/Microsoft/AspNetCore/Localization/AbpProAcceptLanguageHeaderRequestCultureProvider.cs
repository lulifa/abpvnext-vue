namespace Pure.AbpPro.Shared.Hosting.Microservices;

public class AbpProAcceptLanguageHeaderRequestCultureProvider : AcceptLanguageHeaderRequestCultureProvider
{
    public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    {
        var result = await base.DetermineProviderCultureResult(httpContext);

        if (result?.Cultures.Count > 0)
        {
            var culture = result.Cultures.First();
            // 判断是否以 zh - CN(浏览器默认),zh - HK(中国香港),zh - MO(中国澳门),zh - TW(中国台湾)区域开头,如果是一律采用简体中文
            if (culture.Buffer != null && (culture.Buffer.StartsWith("zh-CN") || culture.Buffer.StartsWith("zh-HK") || culture.Buffer.StartsWith("zh-TW") || culture.Buffer.StartsWith("zh-MO")))
            {
                return new ProviderCultureResult("zh-Hans");
            }
        }

        return result;
    }

}