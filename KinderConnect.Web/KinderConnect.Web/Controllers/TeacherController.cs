using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
