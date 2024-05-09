using Pure.AbpPro.BasicModule.Features.Dtos;
using Volo.Abp.FeatureManagement;

namespace Pure.AbpPro.BasicModule.Features;

public interface IVoloFeatureAppService : IApplicationService
{
    /// <summary>
    /// 获取Features
    /// </summary>
    Task<GetFeatureListResultDto> GetAsync(GetFeatureListResultInput input);
    
    /// <summary>
    /// 更新Features
    /// </summary>
    Task UpdateAsync(UpdateFeatureInput input);

    /// <summary>
    /// 删除Features
    /// </summary>
    Task DeleteAsync(DeleteFeatureInput input);
}