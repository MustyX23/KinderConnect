using KinderConnect.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KinderConnect.Web.Controllers
{
    public class ClassroomController : Controller
    {
        private IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            this.classroomService = classroomService;
        }

        public async Task<IActionResult> Index()
        {
            var allClassrooms
                = await classroomService.GetAllClassroomsAsync();

            return View(allClassrooms);
        }
    }
}
