using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class ClassroomTeacher
    {
        [Required]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        [Required]
        public Guid ClassroomId { get; set; }
        public Classroom Classroom { get; set; } = null!;
    }
}
