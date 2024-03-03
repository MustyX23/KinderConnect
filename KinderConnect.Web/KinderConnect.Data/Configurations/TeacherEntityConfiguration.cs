using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinderConnect.Data.Configurations
{
    public class TeacherEntityConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(GenerateTeachers());
        }

        private Teacher[] GenerateTeachers()
        {
            ICollection<Teacher> teachers = new HashSet<Teacher>();

            Teacher teacher;

            teacher = new Teacher()
            {
                FirstName = "Lybomir",
                LastName = "Popov",
                Age = 56,
                Gender = "male",
                QualificationId = 1,
                ImageUrl = "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c",
                TeacherUserId = Guid.Parse("702DE3DD-C1E7-4F40-9131-623AADB7E765"),
            };

            teachers.Add(teacher);

            teacher = new Teacher()
            {
                FirstName = "Mustafa",
                LastName = "Buhov",
                Age = 50,
                Gender = "male",
                QualificationId = 1,
                ImageUrl = "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg",
                TeacherUserId = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
            };

            teachers.Add(teacher);

            return teachers.ToArray();
        }
    }
}
