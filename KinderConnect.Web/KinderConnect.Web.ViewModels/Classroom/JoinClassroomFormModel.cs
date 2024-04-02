using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Child;

namespace KinderConnect.Web.ViewModels.Classroom
{
    public class JoinClassroomFormModel
    {
        public string ClassroomName { get; set; } = null!;

        public string ClassroomImageUrl { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+?\d{1,3}\s?)?(?:\d{3}(?:[-\s]?)\d{2,3}(?:[-\s]?)\d{4})$", ErrorMessage = "With Country Code: Start with a plus sign (+) followed by the country code (1 to 3 digits), then a space, and then the rest of the number.\r\nExample: +359 8945618865\r\nWithout Country Code: Simply enter the local phone number with or without spaces or dashes between digits.\r\nExample: 08945618865")]
        public string ParentGuardianContact { get; set; } = null!;

        [StringLength(MedicalInfoMaxLenght, MinimumLength = MedicalInfoMinLenght)]
        public string? MedicalInformation { get; set; }

        [StringLength(AllergiesMaxLenght, MinimumLength = AllergiesMinLenght)]
        public string? Allergies { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public string ParentGuardianId { get; set; } = null!;

        public string ClassroomId { get; set; } = null!;
    }
}
