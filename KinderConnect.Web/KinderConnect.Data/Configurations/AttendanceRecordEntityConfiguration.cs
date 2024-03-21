﻿using KinderConnect.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderConnect.Data.Configurations
{
    public class AttendanceRecordEntityConfiguration : IEntityTypeConfiguration<AttendanceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
        {
           builder
                .HasOne(ar => ar.Teacher)
                .WithMany(t => t.AttendanceRecords)
                .HasForeignKey(ar => ar.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}