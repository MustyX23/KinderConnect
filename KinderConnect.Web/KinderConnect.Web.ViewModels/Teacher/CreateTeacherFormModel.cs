using KinderConnect.Web.ViewModels.Qualification;
using KinderConnect.Web.ViewModels.User;

namespace KinderConnect.Web.ViewModels.Teacher
{
    public class CreateTeacherFormModel
    {
        public UserViewModel User { get; set; } = null!;
        
        public int QualificationId { get; set; }

        public string ImageURl { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public IEnumerable<QualificationViewModel> Qualifications { get; set; }
            = new HashSet<QualificationViewModel>();
    }
}
