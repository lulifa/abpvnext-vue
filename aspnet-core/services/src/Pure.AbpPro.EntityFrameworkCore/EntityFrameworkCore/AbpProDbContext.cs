﻿using Pure.AbpPro.BasicModule.Dicts.Aggregates;

namespace Pure.AbpPro.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AbpProDbContext : AbpDbContext<AbpProDbContext>, IAbpProDbContext, IBasicModuleDbContext
{
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<FeatureGroupDefinitionRecord> FeatureGroups { get; set; }
    public DbSet<FeatureDefinitionRecord> Features { get; set; }
    public DbSet<FeatureValue> FeatureValues { get; set; }
    public DbSet<PermissionGroupDefinitionRecord> PermissionGroups { get; set; }
    public DbSet<PermissionDefinitionRecord> Permissions { get; set; }
    public DbSet<PermissionGrant> PermissionGrants { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<SettingDefinitionRecord> SettingDefinitionRecords { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    public DbSet<BackgroundJobRecord> BackgroundJobs { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    public DbSet<DataDictionary> DataDictionaries { get; set; }
    public DbSet<DataDictionaryDetail> DataDictionaryDetails { get; set; }

    //public DbSet<Notification> Notifications { get; set; }
    //public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }
    //public DbSet<Language> Languages { get; set; }
    //public DbSet<LanguageText> LanguageTexts { get; set; }

    public AbpProDbContext(DbContextOptions<AbpProDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAbpPro();

        // 基础模块
        builder.ConfigureBasicModule();
    }
}