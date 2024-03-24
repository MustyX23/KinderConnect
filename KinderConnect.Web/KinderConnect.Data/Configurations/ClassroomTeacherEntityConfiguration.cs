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
        }
    }
}
