using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;

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
            try
            {
                var allTeachers
                = await teacherService.GetTeachersForViewAsync();

                return View(allTeachers);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }
        
        public async Task<IActionResult> MyClassrooms()
        {
            string userId = User.GetUserId();

            try
            {
                bool isTeacher
                = await teacherService.IsTeacherByUserIdAsync(userId);

                if (!isTeacher)
                {
                    return NotFound();
                }

                string teacherId
                    = await teacherService.GetTeacherIdByUserIdAsync(userId);

                IEnumerable<MyClassroomViewModel> myClassrooms
                    = await teacherService.GetMyClassroomsByTeacherIdAsync(teacherId);

                return View(myClassrooms);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }

            
        }
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                TeacherDetailsViewModel viewModel
                = await teacherService.GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Index", "Home");
        }
    }
}
