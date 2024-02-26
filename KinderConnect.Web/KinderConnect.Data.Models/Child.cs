using System.ComponentModel.DataAnnotations;

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
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})$")]
        public string ParentGuardianContact { get; set; } = null!;

        [StringLength(1000, MinimumLength = 20)]
        public string? MedicalInformation { get; set; }

        [StringLength(500, MinimumLength = 50)]
        public string? Allergies { get; set; }

        [Required]
        public ApplicationUser ParentGuardian { get; set; } = null!;

        [Required]
        public Guid ClassroomId { get; set; }

        public Classroom Classroom { get; set; } = null!;
    }
}
