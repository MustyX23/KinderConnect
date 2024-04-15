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
                QualificationId = 1,
                ImageUrl = "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg",
                TeacherUserId = Guid.Parse("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
                Summary = "A dedicated drawing teacher, brings creativity and warmth to the kindergarten classroom as he introduces young children to the world of artistic expression through drawing. With a gentle and encouraging approach, Mustafa fosters the development of fine motor skills, creativity, and self-expression in his students. He designs engaging drawing activities tailored to the unique interests and abilities of each child, from exploring simple shapes to creating imaginative scenes."
            };

            teachers.Add(teacher);

            teacher = new Teacher()
            {
                QualificationId = 1,
                ImageUrl = "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c",
                TeacherUserId = Guid.Parse("702DE3DD-C1E7-4F40-9131-623AADB7E765"),
                Summary = "Inspires young minds in the kindergarten classroom with his passion for storytelling and language. With a nurturing and supportive approach, Lyubomir guides children on a journey of exploration and discovery through the world of writing. He encourages creativity and self-expression, helping students develop foundational writing skills such as letter formation, phonics, and basic sentence structure."
            };

            teachers.Add(teacher);


            teacher = new Teacher()
            {
                QualificationId = 2,
                ImageUrl = "https://www.shutterstock.com/image-photo/profile-picture-smiling-millennial-asian-600nw-1836020740.jpg",
                TeacherUserId = Guid.Parse("31C9D7C4-5B0E-46B5-A6DB-0ED766D6B563"),
                Summary = "Savka's dedication, creativity, and compassionate nature make her an exceptional kindergarten teacher. Her unwavering commitment to nurturing the whole child, coupled with her innovative teaching methods and collaborative spirit, positions her as a valued and inspiring educator in the early childhood education community."
            };

            teachers.Add(teacher);

            teacher = new Teacher()
            {
                QualificationId = 3,
                ImageUrl = "https://img.freepik.com/premium-photo/bright-picture-happy-smiling-woman_380164-16026.jpg?size=626&ext=jpg",
                TeacherUserId = Guid.Parse("47D28C7B-A4FC-4617-BBBD-60B05A0BFD45"),
                Summary = "Committed to continuous growth and learning, Amelia actively seeks opportunities to enhance her skills and knowledge in early childhood education. She engages in professional development workshops, conferences, and training sessions to stay updated with the latest trends and best practices in the field."
            };

            teachers.Add(teacher);

            teacher = new Teacher()
            {
                QualificationId = 2,
                ImageUrl = "https://img.freepik.com/premium-photo/close-up-face-young-female-teacher-near-chalkboard-digital-screen-classroom-headshot-positive-female-educator_116407-12458.jpg",
                TeacherUserId = Guid.Parse("37ED60D0-EFE7-4D5A-89C1-8169C7AE008F"),
                Summary = "Ava embraces a child-centered approach to education, focusing on nurturing the whole child's development. She incorporates play-based learning, hands-on activities, and interactive experiences to engage her students and make learning fun and meaningful."
            };

            teachers.Add(teacher);

            teacher = new Teacher()
            {
                QualificationId = 1,                
                ImageUrl = "https://photos.demandstudios.com/getty/article/251/198/86806725.jpg",
                TeacherUserId = Guid.Parse("FFA6F8EB-02F7-4246-AA59-F7CE6D2BE5FF"),
                Summary = "Aurora is a dedicated and passionate kindergarten teacher committed to fostering a nurturing and educational environment for young learners. With her warm personality and innovative teaching methods, she creates an engaging classroom atmosphere where students feel motivated to learn and explore."
            };


            teachers.Add(teacher);

            return teachers.ToArray();
        }
    }
}
