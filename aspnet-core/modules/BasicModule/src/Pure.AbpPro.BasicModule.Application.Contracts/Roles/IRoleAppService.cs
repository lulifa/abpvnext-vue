using Pure.AbpPro.BasicModule.Roles.Dtos;
using Volo.Abp.Identity;

namespace Pure.AbpPro.BasicModule.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task<ListResultDto<IdentityRoleDto>> AllListAsync();

        Task<PagedResultDto<IdentityRoleDto>> ListAsync(PagingRoleListInput input);

        Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);

        Task<IdentityRoleDto> UpdateAsync(UpdateRoleInput input);

        Task DeleteAsync(IdInput input);
    }
}