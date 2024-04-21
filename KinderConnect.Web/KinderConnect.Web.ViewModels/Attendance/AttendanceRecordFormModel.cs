using KinderConnect.Web.ViewModels.Activity;
using KinderConnect.Web.ViewModels.Child;

namespace KinderConnect.Web.ViewModels.Attendance
{
    public class AttendanceRecordFormModel
    {
        public string Id { get; set; }
        public string ClassroomId {  get; set; }

        public string TeacherId { get; set; }

        public string TeacherName {  get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int ActivityId { get; set; }

        public string Actvity { get; set; }

        public string? Comment { get; set; }

        public List<ChildForAttendanceViewModel> Children { get; set; }
            = new List<ChildForAttendanceViewModel>();

        public List<ActivityViewModel> Activities { get; set; }
            = new List<ActivityViewModel>();
    }
}
