using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
