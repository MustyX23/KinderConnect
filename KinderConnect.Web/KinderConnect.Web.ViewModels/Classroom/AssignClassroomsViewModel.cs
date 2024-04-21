namespace KinderConnect.Web.ViewModels.Classroom
{
    public class AssignClassroomsViewModel
    {
        public Guid TeacherId {  get; set; }

        public string TeacherName { get; set; } = null!;

        public List<ClassroomViewModel> Classrooms { get; set; } = null!;

        public List<AssignedClassroomViewModel> AssignedClassrooms { get; set; } = null!;
    }
}
