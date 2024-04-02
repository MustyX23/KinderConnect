using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var allTeachers
                = await teacherService.GetTeachersForViewAsync();

            return View(allTeachers);
        }
        public async Task<IActionResult> Details(string id)
        {
            TeacherDetailsViewModel viewModel
                = await teacherService.GetDetailsByIdAsync(id);

            return View(viewModel);
        }
    }
}
