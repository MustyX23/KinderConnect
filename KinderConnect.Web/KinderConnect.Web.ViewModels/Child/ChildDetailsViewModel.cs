using KinderConnect.Web.ViewModels.Classroom;

namespace KinderConnect.Web.ViewModels.Child
{
    public class ChildDetailsViewModel
    {
        public string Id {  get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool IsActive { get; set; }

        public string ParentGuardianContact { get; set; } = null!;
        public string? MedicalInformation { get; set; }

        public string? Allergies { get; set; }

        public string DateOfBirth { get; set; } = null!;

        public DetailsClassroomViewModel Classroom { get; set; } = null!;
    }
}
