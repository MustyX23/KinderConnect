using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class ChildController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
