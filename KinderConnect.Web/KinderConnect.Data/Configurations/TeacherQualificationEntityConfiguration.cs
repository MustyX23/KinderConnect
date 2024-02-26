using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderConnect.Data.Configurations
{
    public class TeacherQualificationEntityConfiguration : IEntityTypeConfiguration<TeacherQualification>
    {
        public void Configure(EntityTypeBuilder<TeacherQualification> builder)
        {
            builder.HasKey(tq => new {tq.TeacherId, tq.QualificationId});

            builder
                .HasOne(tq => tq.Teacher)
                .WithMany(t => t.TeachersQualifications)
                .HasForeignKey(tq => tq.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(tq => tq.Qualification)
                .WithMany(q => q.TeachersQualifications)
                .HasForeignKey(tq => tq.QualificationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
