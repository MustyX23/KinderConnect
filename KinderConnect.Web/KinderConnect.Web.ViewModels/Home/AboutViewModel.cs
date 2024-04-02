using KinderConnect.Web.ViewModels.Teacher;

namespace KinderConnect.Web.ViewModels.Home
{
    public class AboutViewModel
    {
        public IEnumerable<AllTeacherViewModel> Teachers { get; set; }
            = new HashSet<AllTeacherViewModel>();
    }
}
