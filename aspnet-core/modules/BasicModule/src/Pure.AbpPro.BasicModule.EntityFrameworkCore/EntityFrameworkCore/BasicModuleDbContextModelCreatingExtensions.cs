using Volo.Abp.EntityFrameworkCore.Modeling;

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

        builder.Entity<DataDictionary>(b =>
        {
            b.ToTable(BasicModuleDbProperties.DbTablePrefix + "DataDictionaries", BasicModuleDbProperties.DbSchema);
            b.HasMany(e => e.Details).WithOne().HasForeignKey(uc => uc.DataDictionaryId).IsRequired();
            b.ConfigureByConvention();
        });

        builder.Entity<DataDictionaryDetail>(b =>
        {
            b.ToTable(BasicModuleDbProperties.DbTablePrefix + "DataDictionaryDetails", BasicModuleDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
    }
}
