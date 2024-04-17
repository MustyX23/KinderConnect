using KinderConnect.Services.Data;
using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Teacher;
using KinderConnect.Web.Views.Teacher;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class TeacherController : BaseAdminController
    {
        ITeacherService teacherService;
        IUserService userService;
        IQualificationService qualificationService;

        public TeacherController(
            ITeacherService teacherService,
            IUserService userService,
            IQualificationService qualificationService)
        {
            this.teacherService = teacherService;
            this.userService = userService;
            this.qualificationService = qualificationService;
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
    }
}
