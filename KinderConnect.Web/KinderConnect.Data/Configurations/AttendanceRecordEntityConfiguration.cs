using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace KinderConnect.Data.Configurations
{
    public class AttendanceRecordEntityConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
            builder
                .Property(a => a.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(ar => ar.Teacher)
                .WithMany(t => t.AttendanceRecords)
                .HasForeignKey(ar => ar.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.Classroom)
                .WithMany(c => c.AttendanceRecords)
                .HasForeignKey(a => a.ClassroomId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
