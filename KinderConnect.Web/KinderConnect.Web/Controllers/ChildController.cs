using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Child;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {
        private IChildService childrenService;

        public ChildController(IChildService childrenService)
        {
            this.childrenService = childrenService;
        }

        public async Task<IActionResult> Index()
        {
            string parentGuardianId = User.GetUserId();

            IEnumerable<MyChildrenIndexViewModel> myChildren =
                await childrenService.GetChildrenByParentIdAsync(parentGuardianId);

            return View(myChildren);
        }
        public async Task<IActionResult> Edit(string id)
        {
            EditChildFormModel formModel
                = await childrenService.GetChildForEditByIdAsync(id);

            return View(formModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditChildFormModel formModel)
        {
            try
            {
                await childrenService.EditChildByIdAsync(id, formModel);
                TempData[SuccessMessage] = $"You successfully edited {formModel.FirstName}!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected Error occured while trying editing your child :(");
                return View(formModel);
            }

            return RedirectToAction("Details", "Child", new {id});
        }
        public async Task<IActionResult> Details(string id)
        {
            var viewModel
                = await childrenService.GetChildForDetailsByIdAsync(id);

            return View(viewModel);
        }
    }
}
