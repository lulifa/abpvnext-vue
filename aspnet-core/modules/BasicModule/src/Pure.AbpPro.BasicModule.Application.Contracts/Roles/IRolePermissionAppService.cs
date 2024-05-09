using Pure.AbpPro.BasicModule.Roles.Dtos;

namespace Pure.AbpPro.BasicModule.Roles
{
    public interface IRolePermissionAppService : IApplicationService
    {
        
        Task<PermissionOutput> GetPermissionAsync(GetPermissionInput input);

        Task UpdatePermissionAsync(UpdateRolePermissionsInput input);
    }
}