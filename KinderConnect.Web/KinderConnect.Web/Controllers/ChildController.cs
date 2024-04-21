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

            try
            {
                IEnumerable<MyChildrenIndexViewModel> myChildren =
                await childrenService.GetChildrenByParentIdAsync(parentGuardianId);

                return View(myChildren);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }
        public async Task<IActionResult> Edit(string id)
        {
            string parentGuardianId = User.GetUserId();

            try
            {
                EditChildFormModel formModel
                    = await childrenService.GetChildForEditByIdAsync(id);

                if (formModel == null) 
                {
                    return BadRequest();
                }
                if (formModel.ParentGuardianId.ToLower() != parentGuardianId) 
                {
                    return Unauthorized();
                }

                return View(formModel);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditChildFormModel formModel)
        {
            string parentGuardianId = User.GetUserId();
            var child = await childrenService.GetChildForEditByIdAsync(id);

            try
            {
                if (child == null)
                {
                    return BadRequest();
                }
                if (child.ParentGuardianId.ToLower() != parentGuardianId)
                {
                    return Unauthorized();
                }

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
            string parentGuardian = User.GetUserId();
            try
            {
                var viewModel
                = await childrenService.GetChildForDetailsByIdAsync(id);

                if (viewModel == null)
                {
                    return BadRequest();
                }
                if (viewModel.ParentGuardianId.ToLower() != parentGuardian)
                {
                    return Unauthorized();
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
