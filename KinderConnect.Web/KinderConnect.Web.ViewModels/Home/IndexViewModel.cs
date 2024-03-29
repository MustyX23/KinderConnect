using KinderConnect.Web.ViewModels.Activity;
using KinderConnect.Web.ViewModels.BlogPost;

namespace KinderConnect.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<AllActivitiesViewModel> Activities { get; set; }
            = new HashSet<AllActivitiesViewModel>();

        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
            = new HashSet<BlogPostViewModel>();
    }
}
