namespace Pure.AbpPro.BasicModule.OrganizationUnits.Dto;

public class RemoveRoleToOrganizationUnitInput
{
    public Guid RoleId { get; set; }
    
    public Guid OrganizationUnitId { get; set; }
}