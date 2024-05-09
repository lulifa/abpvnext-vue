using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Pure.AbpPro.BasicModule.EntityFrameworkCore;

public static class BasicModuleDbContextModelCreatingExtensions
{
    public static void ConfigureBasicModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
    }
}
