using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class ClassroomController : BaseAdminController
    {
        private IClassroomService classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            this.classroomService = classroomService;
        }

        public async Task<IActionResult> All(AllClassroomsQueryModel queryModel)
        {
            var model = await classroomService.AllAsync(queryModel);
            return View(model);
        }
        public IActionResult Create()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var formModel = new CreateClassroomFormModel(); 
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassroomFormModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            
            await classroomService.CreateAsync(model);
            return RedirectToAction("All", "Classroom", new {Area = "Admin"});
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var formModel = await classroomService.GetClassroomForEditByIdAsync(id);
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditClassroomFormModel formModel)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await classroomService.EditAsync(id, formModel);
            return RedirectToAction("All", "Classroom");
        }

        [HttpPost]
        public async Task<IActionResult> SoftRemove(string id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong...");
                TempData[ErrorMessage] = $"Something went wrong...:( Please try again later!";
                return RedirectToAction("All", "Classroom");                
            }
            await classroomService.SoftRemoveClassroomByIdAsync(id);
            return RedirectToAction("All", "Classroom");
        }
    }
}
