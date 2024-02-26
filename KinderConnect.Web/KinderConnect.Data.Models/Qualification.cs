using System.ComponentModel.DataAnnotations;

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
        [StringLength(120)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 15)]
        public string Description { get; set; } = null!;
        public ICollection<TeacherQualification> TeachersQualifications { get; set; }
    }
}
