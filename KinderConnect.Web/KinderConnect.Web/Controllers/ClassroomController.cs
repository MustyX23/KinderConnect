using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KinderConnect.Web.Controllers
{
    public class ClassroomController : Controller
    {
        private IClassroomService classroomService;
        private IChildrenService childrenService;

        public ClassroomController(
            IClassroomService classroomService,
            IChildrenService childrenService)
        {
            this.classroomService = classroomService;
            this.childrenService = childrenService;
        }

        public async Task<IActionResult> Index()
        {
            var allClassrooms
                = await classroomService.GetAllClassroomsAsync();

            return View(allClassrooms);
        }

        public async Task<IActionResult> JoinClassroom(string id)
        {
            var formModel = 
                await classroomService.GetJoinClassroomFormModelByIdAsync(id);

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> JoinClassroom(JoinClassroomFormModel model)
        {
            string parentguardianId = User.GetUserId();

            await childrenService.JoinChildToClassroomAsync(model, parentguardianId);

            return RedirectToAction("Index", "Home");
        }

    }
}
