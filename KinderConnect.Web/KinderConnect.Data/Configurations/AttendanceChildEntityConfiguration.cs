using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KinderConnect.Data.Configurations
{
    public class AttendanceChildEntityConfiguration : IEntityTypeConfiguration<AttendanceChild>
    {
        public void Configure(EntityTypeBuilder<AttendanceChild> builder)
        {
            builder
                .HasKey(ac => new { ac.AttendanceRecordId, ac.ChildId });

            builder
                .HasOne(ac => ac.AttendanceRecord)
                .WithMany(ac => ac.AttendanceChildren)
                .HasForeignKey(ac => ac.AttendanceRecordId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ac => ac.Child)
                .WithMany(ac => ac.AttendanceChildren)
                .HasForeignKey(ac => ac.ChildId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
