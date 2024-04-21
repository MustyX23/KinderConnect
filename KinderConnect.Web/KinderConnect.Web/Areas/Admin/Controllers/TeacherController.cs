using KinderConnect.Data.Models;
using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Classroom;
using KinderConnect.Web.ViewModels.Teacher;
using KinderConnect.Web.Views.Teacher;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;
using static KinderConnect.Common.GeneralApplicationConstants;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class TeacherController : BaseAdminController
    {
        ITeacherService teacherService;
        IUserService userService;
        IQualificationService qualificationService;
        IClassroomService classroomService;

        public TeacherController(
            ITeacherService teacherService,
            IUserService userService,
            IQualificationService qualificationService,
            IClassroomService classroomService)
        {
            this.teacherService = teacherService;
            this.userService = userService;
            this.qualificationService = qualificationService;
            this.classroomService = classroomService;
        }
        public async Task<IActionResult> All([FromQuery]AllTeachersQueryModel queryModel)
        {
            var allTeachers = await teacherService.AllAsync(queryModel);
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(allTeachers);
            }
            return View(allTeachers);
        }

        public async Task<IActionResult> Create(string userId)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            var userViewModel
                = await userService.GetUserViewModelByIdAsync(userId);

            var qualifications
                = await qualificationService.GetAllQualificationsViewModels();

            CreateTeacherFormModel formModel = new CreateTeacherFormModel() 
            {
                User = userViewModel,
                Qualifications = qualifications
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userId, CreateTeacherFormModel formModel)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var userViewModel
                = await userService.GetUserViewModelByIdAsync(userId);

            var qualifications
               = await qualificationService.GetAllQualificationsViewModels();

            formModel.User = userViewModel;
            formModel.Qualifications = qualifications;

            await teacherService.UpgradeToTeacherByUserIdAsync(userId, formModel);
            TempData[SuccessMessage] = $"You successfully upgraded {formModel.User.FullName} to a teacher!";

            return RedirectToAction("All", "Teacher");
        }
        public async Task<IActionResult> AssignClassrooms(string teacherId)
        {            
            AssignClassroomsViewModel viewModel
                = await classroomService.GetAssignClassroomsViewModelByTeacherIdAsync(teacherId);

            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (viewModel == null)
            {
                return BadRequest();
            }

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignClassrooms(Guid teacherId, List<Guid> classroomIds)
        {
            bool isTeacherLeading = await classroomService.IsTeacherAlreadyLeadingClassesAsync(teacherId, classroomIds);
            var teacher = await teacherService.GetTeacherByIdAsync(teacherId);

            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (teacher == null)
            {
                return BadRequest();
            }
            if (isTeacherLeading)
            {
                ModelState.AddModelError(string.Empty,$"{teacher.TeacherUser.FirstName + " " + teacher.TeacherUser.LastName} is already leading those classrooms.");
                TempData[ErrorMessage] = $"{teacher.TeacherUser.FirstName + " " + teacher.TeacherUser.LastName} is already leading those classrooms.";
                return RedirectToAction("All", "Teacher");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong... please try again later.");
                TempData[ErrorMessage] = $"Something went wrong... please try again later.";
                return RedirectToAction("All", "Teacher");
            }
            try
            {
                await classroomService.AssignClassroomsToTeacherAsync(teacherId, classroomIds);
                TempData[SuccessMessage] = $"You successfully assigned classrooms to {teacher.TeacherUser.FirstName + " " + teacher.TeacherUser.LastName}";
                return RedirectToAction("All", "Teacher");
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Index", "Home");
        }
    }
}
