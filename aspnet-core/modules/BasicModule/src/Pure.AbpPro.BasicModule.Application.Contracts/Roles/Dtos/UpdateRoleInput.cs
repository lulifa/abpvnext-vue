using Volo.Abp.Identity;

namespace Pure.AbpPro.BasicModule.Roles.Dtos
{
    public class UpdateRoleInput
    {
        public Guid RoleId { get; set; }

        public IdentityRoleUpdateDto RoleInfo { get; set; }
    }
}