using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Id = Guid.NewGuid();
            ClassroomsTeachers = new HashSet<ClassroomTeacher>();
            TeachersQualifications = new HashSet<TeacherQualification>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required]
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; } = null!;

        [Required]
        public ApplicationUser TeacherUser { get; set; } = null!;
        public ICollection<ClassroomTeacher> ClassroomsTeachers { get; set; }
        public ICollection<TeacherQualification> TeachersQualifications { get; set; } = null!;
    }
}
