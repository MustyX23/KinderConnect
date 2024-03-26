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
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public ICollection<Child> Children { get; set; }

        public ICollection<ClassroomTeacher> ClassroomsTeachers { get; set; } = null!;
    }
}
