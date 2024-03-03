using System.ComponentModel.DataAnnotations;

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
        public TimeSpan End { get; set; }

        [Required]
        public int ActivityId { get; set; }       

        public string? Comment { get; set; }

        [Required]
        public Child Child { get; set; } = null!;

        [Required]
        public Teacher Teacher { get; set; } = null!;

        [Required]
        public Activity Activity { get; set; } = null!;

    }
}
