using System.ComponentModel.DataAnnotations;

namespace BankMVCApp.Models.ViewModels
{
    public class NoSpaceAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            if(value.ToString().Contains(" "))
            {
                var errorMessage = FormatErrorMessage((validationContext.DisplayName));
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}