﻿namespace Pure.AbpPro.BasicModule.OrganizationUnits.Dto;

public class CreateOrganizationUnitInput : IValidatableObject
{
    public string DisplayName { get; set; }

    public Guid? ParentId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var localization = validationContext.GetRequiredService<IStringLocalizer<AbpProLocalizationResource>>();
        if (DisplayName.IsNullOrWhiteSpace())
        {
            yield return new ValidationResult(
                localization[AbpProLocalizationErrorCodes.ErrorCode100003, nameof(DisplayName)],
                new[] {  nameof(DisplayName) }
            );
        }
    }
}