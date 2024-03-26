using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Child;

namespace KinderConnect.Data.Models
{
    public class Child
    {
        public Child()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        [Range(AgeMin, AgeMax)]
        public int Age { get; set; }        

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})$")]
        public string ParentGuardianContact { get; set; } = null!;

        [StringLength(MedicalInfoMaxLenght, MinimumLength = MedicalInfoMinLenght)]
        public string? MedicalInformation { get; set; }

        [StringLength(AllergiesMaxLenght, MinimumLength = AllergiesMinLenght)]
        public string? Allergies { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Guid ParentGuardianId { get; set; }

        [Required]
        public ApplicationUser ParentGuardian { get; set; } = null!;

        [Required]
        public Guid ClassroomId { get; set; }

        public Classroom Classroom { get; set; } = null!;
    }
}
