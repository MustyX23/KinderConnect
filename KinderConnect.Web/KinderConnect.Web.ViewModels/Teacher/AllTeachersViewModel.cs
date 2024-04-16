namespace KinderConnect.Web.ViewModels.Teacher
{
    public class AllTeachersViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public bool IsActive { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Qualification { get; set; }
    }
}
