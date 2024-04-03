using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using static KinderConnect.Common.NotificationMessagesConstants;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class ClassroomController : Controller
    {
        private IClassroomService classroomService;
        private IChildrenService childrenService;

        public ClassroomController(
            IClassroomService classroomService,
            IChildrenService childrenService)
        {
            this.classroomService = classroomService;
            this.childrenService = childrenService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allClassrooms
                = await classroomService.GetAllClassroomsAsync();

            return View(allClassrooms);
        }

        public async Task<IActionResult> JoinClassroom(string id)
        {
            string parentGuardianId = User.GetUserId();

            try
            {
                var formModel =
                await classroomService.GetJoinClassroomFormModelByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                GeneralError();
            }

            return RedirectToAction("Index", "Classroom");
            
        }

        [HttpPost]
        public async Task<IActionResult> JoinClassroom(JoinClassroomFormModel model)
        {
            string parentguardianId = User.GetUserId();

            bool childIsAlreadyInAClassroom
                = await childrenService.IsChildAlreadyInAClassroomAsync(model, parentguardianId);

            bool seatsAvailable
                = await classroomService.IsClassroomSeatsAvailableAsync(model.ClassroomId);

            if (!seatsAvailable)
            {
                ModelState.AddModelError(string.Empty, "Sorry, the classroom is already full.");
                TempData[ErrorMessage] = $"The classroom {model.ClassroomName} is already full.";
                return RedirectToAction("Index", "Classroom");
            }
            if (childIsAlreadyInAClassroom)
            {
                ModelState.AddModelError(string.Empty, "The child's already in a classroom.");
                TempData[ErrorMessage] = $"Your child's already in the {model.ClassroomName} classroom.";
                return View(model);
            }

            if (!IsValidAgeForClassroom(model.DateOfBirth, model.ClassroomMinimumAge, model.ClassroomMaximumAge))
            {
                ModelState.AddModelError(string.Empty, "The child's age does not meet the classroom requirements.");
                TempData[ErrorMessage] = $"Your child's age doesn't meet {model.ClassroomName} classroom requirements.";
                return View(model);
            }
            try
            {
                await childrenService.JoinChildToClassroomAsync(model, parentguardianId);
                TempData[SuccessMessage] = $"You successfully added {model.FirstName} to the Kindergarden!";
            }
            catch (Exception)
            {
                GeneralError();
            }            

            return RedirectToAction("Index", "Home");
        }
        private bool IsValidAgeForClassroom(DateTime dateOfBirth, int minAge, int maxAge)
        {
            int childAge = DateTime.Now.Year - dateOfBirth.Year;

            return childAge >= minAge && childAge <= maxAge;
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Home", "Index");
        }

    }
}
