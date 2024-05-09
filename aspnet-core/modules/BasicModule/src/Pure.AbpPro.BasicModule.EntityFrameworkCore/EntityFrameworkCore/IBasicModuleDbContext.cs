namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

[ConnectionStringName(BasicModuleDbProperties.ConnectionStringName)]
public interface IBasicModuleDbContext :
    IEfCoreDbContext,
    IFeatureManagementDbContext,
    IIdentityDbContext,
    IPermissionManagementDbContext,
    ISettingManagementDbContext,
    ITenantManagementDbContext,
    IBackgroundJobsDbContext,
    IAuditLoggingDbContext
{

}
