using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.Views.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class TeacherController : BaseAdminController
    {
        ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
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
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
