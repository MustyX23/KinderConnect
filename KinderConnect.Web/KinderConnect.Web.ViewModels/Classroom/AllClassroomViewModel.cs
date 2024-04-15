namespace KinderConnect.Web.ViewModels.Classroom
{
    public class AllClassroomViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Information { get; set; } = null!;

        public int MinimumAge { get; set; }

        public int MaximumAge { get; set; }

        public int TotalSeats { get; set; }

        public string TutionFee { get; set; } = null!;

        public bool SeatsAvailable { get; set; }

    }
}
