using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Child;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class ChildController : Controller
    {
        private IChildrenService childrenService;

        public ChildController(IChildrenService childrenService)
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
        public async Task<IActionResult> Details(string id)
        {
            var viewModel
                = await childrenService.GetChildForDetailsByIdAsync(id);

            return View(viewModel);
        }
    }
}
