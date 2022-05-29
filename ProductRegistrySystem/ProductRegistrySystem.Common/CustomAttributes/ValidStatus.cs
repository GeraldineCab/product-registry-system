using System;
using System.ComponentModel.DataAnnotations;

namespace ProductRegistrySystem.Common.CustomAttributes
{
    public class ValidStatus : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var status = Convert.ToInt32(value);
            if (status == 1 || status == 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Status is invalid. Please provide one of the following values: 0 = Inactive or 1 = Active");
            }
        }
    }
}
