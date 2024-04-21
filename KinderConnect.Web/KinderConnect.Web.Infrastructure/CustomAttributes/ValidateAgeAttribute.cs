using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Web.Infrastructure.CustomAttributes
{
    public class ValidateAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public ValidateAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (DateTime.Now.Year - date.Year < _minimumAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
