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
            AttendanceRecords = new HashSet<AttendanceRecord>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; } = null!;

        [Required]
        public Guid TeacherUserId { get; set; }

        [Required]
        public ApplicationUser TeacherUser { get; set; } = null!;
        public ICollection<ClassroomTeacher> ClassroomsTeachers { get; set; }
        public ICollection<TeacherQualification> TeachersQualifications { get; set; } = null!;

        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = null!;
    }
}
