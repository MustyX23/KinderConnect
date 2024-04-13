using System.ComponentModel.DataAnnotations;
using static KinderConnect.Common.EntityValidationConstants.Classroom;

namespace KinderConnect.Data.Models
{
    public class Classroom
    {
        public Classroom()
        {
            Id = Guid.NewGuid();
            Children = new HashSet<Child>();
            ClassroomsTeachers = new HashSet<ClassroomTeacher>();
            AttendanceRecords = new HashSet<AttendanceRecord>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(InfoMaxLenght, MinimumLength = InfoMaxLenght)]
        public string Information { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(MinimumAgeMinLenght, MinimumAgeMaxLenght)]
        public int MinimumAge { get; set; }

        [Required]
        [Range(MaximumAgeAgeMinLenght, MaximumAgeAgeMaxLenght)]
        public int MaximumAge { get; set; }

        [Required]
        public int TotalSeats { get; set; }

        [Required]
        public decimal TutionFee { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Child> Children { get; set; }

        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }

        public ICollection<ClassroomTeacher> ClassroomsTeachers { get; set; } = null!;
    }
}
