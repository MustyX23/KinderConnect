using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> JoinClassroom(string id)
        {
            JoinClassroomFormModel formModel = new JoinClassroomFormModel();
            return View(formModel);
        }
    }
}
