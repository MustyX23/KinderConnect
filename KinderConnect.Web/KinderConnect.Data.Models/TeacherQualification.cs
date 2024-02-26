using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class TeacherQualification
    {
        [Required]
        public string TeacherId { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;

        [Required]
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; } = null!;
    }
}