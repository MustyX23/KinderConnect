using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class Classroom
    {
        public Classroom()
        {
            Id = Guid.NewGuid();
            Children = new HashSet<Child>();
            ClassroomsTeachers = new HashSet<ClassroomTeacher>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public ICollection<Child> Children { get; set; }

        public ICollection<ClassroomTeacher> ClassroomsTeachers { get; set; } = null!;
    }
}
