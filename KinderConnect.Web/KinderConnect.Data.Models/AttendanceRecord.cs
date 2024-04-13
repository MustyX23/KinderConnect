﻿using System.ComponentModel.DataAnnotations;

namespace KinderConnect.Data.Models
{
    public class AttendanceRecord
    {
        public AttendanceRecord()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public Guid ChildId { get; set; }

        [Required]
        public Guid TeacherId { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [Required]
        public Guid ClassroomId { get; set; }

        public string? Comment { get; set; }

        public bool IsActive {  get; set; }

        [Required]
        public Child Child { get; set; } = null!;

        [Required]
        public Teacher Teacher { get; set; } = null!;

        [Required]
        public Activity Activity { get; set; } = null!;

        [Required]
        public Classroom Classroom { get; set; } = null!;

    }
}
