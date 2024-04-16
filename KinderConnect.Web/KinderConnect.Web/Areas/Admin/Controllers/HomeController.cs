using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
