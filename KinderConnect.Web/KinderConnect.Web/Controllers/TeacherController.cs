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

                if (allTeachers == null)
                {
                    return BadRequest();
                }

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

                string teacherId
                    = await teacherService.GetTeacherIdByUserIdAsync(userId);

                if (!isTeacher)
                {
                    TempData[ErrorMessage] = "You don't have permissions for this page.";
                    ModelState.AddModelError(string.Empty, "You don't have permissions for this page.");
                    return RedirectToAction("Index", "Home");
                }
                if (teacherId == null)
                {
                    return Unauthorized();
                }

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

                if (viewModel == null)
                {
                    return BadRequest();
                }

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
