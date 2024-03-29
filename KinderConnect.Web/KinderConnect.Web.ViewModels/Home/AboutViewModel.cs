using KinderConnect.Web.ViewModels.Teacher;

namespace KinderConnect.Web.ViewModels.Home
{
    public class AboutViewModel
    {
        public IEnumerable<TeachersForViewModel> Teachers { get; set; }
            = new HashSet<TeachersForViewModel>();
    }
}
