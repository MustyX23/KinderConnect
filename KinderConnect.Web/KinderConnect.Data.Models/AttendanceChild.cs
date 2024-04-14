namespace KinderConnect.Data.Models
{
    public class AttendanceChild
    {
        public Guid ChildId { get; set; }
        public Guid AttendanceRecordId { get; set; }
        public bool IsPresent { get; set; }
        public string? Comment {  get; set; }
        public Child Child { get; set; }
        public AttendanceRecord AttendanceRecord { get; set; }
    }
}
