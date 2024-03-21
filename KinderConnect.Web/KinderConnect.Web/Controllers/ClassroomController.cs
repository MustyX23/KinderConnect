using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
