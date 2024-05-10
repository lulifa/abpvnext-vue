using AutoMapper;
using Pure.AbpPro.BasicModule.AuditLogs;
using Pure.AbpPro.BasicModule.IdentitySecurityLogs;
using Pure.AbpPro.BasicModule.Users.Dtos;

namespace Pure.AbpPro.BasicModule;

public class BasicModuleApplicationAutoMapperProfile : Profile
{
    public BasicModuleApplicationAutoMapperProfile()
    {
        CreateMap<AuditLog, PagingAuditLogOutput>()
            .ForMember(dest => dest.ExecutionTime,
                opt => opt.MapFrom(s => s.ExecutionTime.ToString("O")));
        CreateMap<AuditLogAction, PagingAuditLogActionOutput>()
            .ForMember(dest => dest.ExecutionTime,
                opt => opt.MapFrom(s => s.ExecutionTime.ToString("O")));

        CreateMap<EntityChange, PagingEntityChangeOutput>()
            .ForMember(dest => dest.ChangeTypeDescription,
                opt => opt.MapFrom(s => s.ChangeType.ToDescription()))
            .ForMember(dest => dest.ChangeTime,
                opt => opt.MapFrom(s => s.ChangeTime.ToString("O")));
        CreateMap<EntityPropertyChange, PagingEntityPropertyChangeOutput>();

        CreateMap<Volo.Abp.Identity.IdentityUser, LoginOutput>()
            .ForMember(dest => dest.Token, opt => opt.Ignore());
        CreateMap<IdentityUser, ExportIdentityUserOutput>()
            .ForMember(e => e.CreationTimeFormat, opt => opt.Ignore())
            .ForMember(e => e.Status, opt => opt.Ignore());
        CreateMap<OrganizationUnit, OrganizationUnitDto>();
        CreateMap<IdentityUser, GetOrganizationUnitUserOutput>();
        CreateMap<IdentityUser, GetUnAddUserOutput>();
        CreateMap<IdentityRole, GetOrganizationUnitRoleOutput>();
        CreateMap<IdentityRole, GetUnAddRoleOutput>();
        CreateMap<IdentitySecurityLog, PagingIdentitySecurityLogOutput>();
        CreateMap<TenantConnectionString, PageTenantConnectionStringOutput>();
    }
}
