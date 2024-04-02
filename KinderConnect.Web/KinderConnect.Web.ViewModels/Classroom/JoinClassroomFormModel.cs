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
        [RegularExpression(@"^(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})$")]
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
