using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
