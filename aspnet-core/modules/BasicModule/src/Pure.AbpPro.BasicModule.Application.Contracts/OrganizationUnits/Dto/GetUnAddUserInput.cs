namespace Pure.AbpPro.BasicModule.OrganizationUnits.Dto;

public class GetUnAddUserInput : PagingBase
{
    public Guid OrganizationUnitId { get; set; }

    public string Filter { get; set; }
}