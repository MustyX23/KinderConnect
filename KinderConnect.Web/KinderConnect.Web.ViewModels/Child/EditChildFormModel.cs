using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Child;

namespace KinderConnect.Web.ViewModels.Child
{
    public class EditChildFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+?\d{1,3}\s?)?(?:\d{3}(?:[-\s]?)\d{2,3}(?:[-\s]?)\d{4})$", ErrorMessage = "With Country Code: Start with a plus sign (+) followed by the country code (1 to 3 digits), then a space, and then the rest of the number.\r\nExample: +359 8945618865\r\nWithout Country Code: Simply enter the local phone number with or without spaces or dashes between digits.\r\nExample: 08945618865")]
        public string ParentGuardianContact { get; set; }

        public string ParentGuardianId { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }
        public string? MedicalInformation { get; set; }
        public string? Allergies { get; set; }

    }
}
