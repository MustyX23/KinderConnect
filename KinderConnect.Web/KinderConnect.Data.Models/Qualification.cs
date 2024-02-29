using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Qualification;

namespace KinderConnect.Data.Models
{
    public class Qualification
    {
        public Qualification()
        {
            TeachersQualifications = new HashSet<TeacherQualification>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
        public ICollection<TeacherQualification> TeachersQualifications { get; set; }
    }
}
