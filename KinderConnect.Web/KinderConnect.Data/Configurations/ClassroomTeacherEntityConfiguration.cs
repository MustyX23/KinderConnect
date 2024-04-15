using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinderConnect.Data.Configurations
{
    public class ClassroomTeacherEntityConfiguration : IEntityTypeConfiguration<ClassroomTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassroomTeacher> builder)
        {
            builder
                .HasKey(ct => new {ct.TeacherId, ct.ClassroomId});

            builder.HasData(GenerateClassroomTeachers());
        }

        private ClassroomTeacher[] GenerateClassroomTeachers()
        {
            ICollection<ClassroomTeacher> classroomTeachers = new HashSet<ClassroomTeacher>();

            ClassroomTeacher classroomTeacher;

            //Milena & Lyubliana
            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("F51FD481-6CA4-45B8-9848-304132B479F8"),
                ClassroomId = Guid.Parse("632BC679-3CC2-45B7-971B-6A92105321DE")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("F51FD481-6CA4-45B8-9848-304132B479F8"),
                ClassroomId = Guid.Parse("958B5667-9055-40A7-B7B2-81C19AFE3329")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("32521DE9-EB61-49D9-B81F-B3DC5467FB4C"),
                ClassroomId = Guid.Parse("958B5667-9055-40A7-B7B2-81C19AFE3329")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("32521DE9-EB61-49D9-B81F-B3DC5467FB4C"),
                ClassroomId = Guid.Parse("632BC679-3CC2-45B7-971B-6A92105321DE")
            };

            classroomTeachers.Add(classroomTeacher);

            //Aurora & Ava
            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("A5738953-616E-448C-8D2D-C1EB5921F6BA"),
                ClassroomId = Guid.Parse("C12F8035-D854-4CDC-BAD7-489237B10FDF")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("A5738953-616E-448C-8D2D-C1EB5921F6BA"),
                ClassroomId = Guid.Parse("4FAA63AB-F5F8-45AE-BDC4-2EB42CA9B266")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("32521DE9-EB61-49D9-B81F-B3DC5467FB4C"),
                ClassroomId = Guid.Parse("C12F8035-D854-4CDC-BAD7-489237B10FDF")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("32521DE9-EB61-49D9-B81F-B3DC5467FB4C"),
                ClassroomId = Guid.Parse("4FAA63AB-F5F8-45AE-BDC4-2EB42CA9B266")
            };

            classroomTeachers.Add(classroomTeacher);

            //Amelia & Savka

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("C8A7E14B-6543-47E9-BEAD-0E19F3A199C6"),
                ClassroomId = Guid.Parse("F9451730-FA24-466B-B852-4FA8D6EB1DFC")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("C8A7E14B-6543-47E9-BEAD-0E19F3A199C6"),
                ClassroomId = Guid.Parse("47196D67-0A98-4305-9E08-D8A2E1AE22C8")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("365D5460-43BB-4094-BD01-46F0C3197590"),
                ClassroomId = Guid.Parse("A92ED02A-BBF0-426B-B0F5-4BD8B89C33EA")
            };

            classroomTeachers.Add(classroomTeacher);

            classroomTeacher = new ClassroomTeacher()
            {
                TeacherId = Guid.Parse("365D5460-43BB-4094-BD01-46F0C3197590"),
                ClassroomId = Guid.Parse("8375650A-E0A4-4EB4-A5AB-849B955C79DA")
            };

            classroomTeachers.Add(classroomTeacher);

            return classroomTeachers.ToArray();
        }
    }
}
