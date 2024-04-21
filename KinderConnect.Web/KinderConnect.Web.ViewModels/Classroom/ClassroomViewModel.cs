namespace KinderConnect.Web.ViewModels.Classroom
{
    public class ClassroomViewModel
    {
        public Guid Id { get; set; }
        public string ClassroomName { get; set; } = null!;

        public string ClassroomImageUrl { get; set; } = null!;

        public int ClassroomMinimumAge { get; set; }

        public int ClassroomMaximumAge { get; set; }
    }
}
