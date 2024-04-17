using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Activity;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;
namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class ActivityController : BaseAdminController
    {
        private readonly IActivityService activityService;
        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }
        public async Task<IActionResult> All()
        {
            try
            {
                var allActivities
                    = await activityService.GetAllActivitiesAsync();

                return View(allActivities);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult Create()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            ActivityFormModel activityFormModel = new();

            return View(activityFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityFormModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            try
            {
                await activityService.CreateAsync(model);
                TempData[SuccessMessage] = $"You successfully created the activity: {model.Name}";
                return RedirectToAction("All", "Activity");
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var formModel 
                = await activityService.GetActivityForEditByIdAsync(id);

            return View(formModel);  
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActivityFormModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await activityService.EditByIdAsync(id, model);
                TempData[SuccessMessage] = $"You successfully edited the activity: {model.Name}"; ;
                return RedirectToAction("All", "Activity");
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> SoftRemove(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await activityService.SoftRemoveByIdAsync(id);
                TempData[ErrorMessage] = $"You successfully removed the activity";
                return RedirectToAction("All", "Activity");
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
