using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.Classroom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;
using static KinderConnect.Common.GeneralApplicationConstants;

namespace KinderConnect.Web.Controllers
{
    [Authorize]
    public class ClassroomController : Controller
    {
        private IClassroomService classroomService;
        private IChildService childrenService;
        private IUserService userService;

        public ClassroomController(
            IClassroomService classroomService,
            IChildService childrenService,
            IUserService userService)
        {
            this.classroomService = classroomService;
            this.childrenService = childrenService;
            this.userService = userService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery]AllClassroomsQueryModel queryModel)
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("All", "Classroom", new { Area = AdminAreaName });
            }

            try
            {
                var allClassrooms
                    = await classroomService.AllAsync(queryModel);

                return View(allClassrooms);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Classroom");
            }

        }

        [HttpGet("JoinClassroom/{id}")]
        public async Task<IActionResult> JoinClassroom(string id)
        {
            string parentGuardianId = User.GetUserId();

            string phoneNumber = await userService.GetPhoneNumberByIdAsync(parentGuardianId);

            try
            {
                var formModel =
                await classroomService.GetJoinClassroomFormModelByIdAsync(id);

                if (phoneNumber != null)
                {
                    formModel.ParentGuardianContact = phoneNumber;
                }

                return View(formModel);
            }
            catch (Exception)
            {
                GeneralError();
            }

            return RedirectToAction("Index", "Classroom");
            
        }
        [HttpPost("JoinClassroom/{id}")]
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
                TempData[ErrorMessage] = $"Your child's already in a classroom.";
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
                await classroomService.DecreaseTotalSeatsByIdAsync(model.ClassroomId);
                TempData[SuccessMessage] = $"You successfully added {model.FirstName} to the Kindergarden!";
            }
            catch (Exception)
            {
                GeneralError();
            }            

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> JoinClassroomByChild(string id)
        {
            string parentGuardianId = User.GetUserId();
            try
            {
                var formModel =
                await classroomService.GetJoinClassroomByChildViewModelByIdAsync(id);

                if (formModel == null)
                {
                    return BadRequest();
                }

                return View(formModel);
            }
            catch (Exception)
            {
                GeneralError();
            }

            return RedirectToAction("Index", "Classroom");

        }
        [HttpPost]
        public async Task<IActionResult> JoinClassroomByChild(string classroomId, string childId)
        {
            string parentGuardianId = User.GetUserId();

            var child
                = await childrenService.GetChildByIdAsync(childId);

            var classroomViewModel
                = await classroomService.GetClassroomViewModelByIdAsync(classroomId);

            bool childIsAlreadyInAClassroom
                = await childrenService.IsChildAlreadyInAClassroomByIdAsync(childId);

            bool seatsAvailable
                = await classroomService.IsClassroomSeatsAvailableAsync(classroomId);

            if (child == null)
            {
                return BadRequest();
            }
            if (child.ParentGuardianId != Guid.Parse(parentGuardianId))
            {
                return Unauthorized();
            }
            if (!seatsAvailable)
            {
                ModelState.AddModelError(string.Empty, "Sorry, the classroom is already full.");
                TempData[ErrorMessage] = $"The classroom {classroomViewModel.ClassroomName} is already full.";
                return RedirectToAction("Index", "Classroom");
            }
            if (childIsAlreadyInAClassroom)
            {
                ModelState.AddModelError(string.Empty, "The child's already in a classroom.");
                TempData[ErrorMessage] = $"Your child's already in a classroom.";
                return RedirectToAction("Index", "Child");
            }

            if (!IsValidAgeForClassroom(child.DateOfBirth, classroomViewModel.ClassroomMinimumAge, classroomViewModel.ClassroomMaximumAge))
            {
                ModelState.AddModelError(string.Empty, "The child's age does not meet the classroom requirements.");
                TempData[ErrorMessage] = $"Your child's age doesn't meet {classroomViewModel.ClassroomName} classroom requirements.";
                return RedirectToAction("Index", "Classroom");
            }
            if (child == null)
            {
                TempData[ErrorMessage] = "The Child doesn't exist in the system.";
                return RedirectToAction("Index", "Classroom");
            }

            try
            {
                await childrenService.JoinChildToClassroomByIdAsync(classroomId, childId, parentGuardianId);
                await classroomService.DecreaseTotalSeatsByIdAsync(classroomId);

                TempData[SuccessMessage] = $"You successfully added {child.FirstName} to the Kindergarden!";
                return RedirectToAction("Index", "Child");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Classroom");
            }
        }
        public async Task<IActionResult> LeaveClassroom(string childId)
        {
            string parentGuardianId = User.GetUserId();

            try
            {
                var child
                    = await childrenService.GetChildByIdAsync(childId);

                if (child == null)
                {
                    return BadRequest();
                }
                if (child.ParentGuardianId != Guid.Parse(parentGuardianId))
                {
                    return Unauthorized();
                }

                LeaveClassroomViewModel viewModel
                    = await classroomService.GetLeaveClassroomViewModelByChildIdAsync(childId);

                return View(viewModel);

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Classroom");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> LeaveClassroom(string childId, string classroomId)
        {
            string parentGuardianId = User.GetUserId();

            try
            {
                var childViewModel
                    = await childrenService.GetLeaveChildViewModelByIdAsync(childId);

                var classroomViewModel
                    = await classroomService.GetClassroomViewModelByIdAsync(classroomId);

                if (childViewModel == null || classroomViewModel == null)
                {
                    return BadRequest();
                }
                if (childViewModel.ParentGuardianId.ToLower() != parentGuardianId)
                {
                    return Unauthorized();
                }

                await childrenService.LeaveClassroomByChildIdAsync(childId);
                await classroomService.DecreaseTotalSeatsByIdAsync(classroomId);

                TempData[SuccessMessage] = $"You successfully removed {childViewModel.FirstName} from the {classroomViewModel.ClassroomName}!";
                return RedirectToAction("Index", "Child");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
        private bool IsValidAgeForClassroom(DateTime dateOfBirth, int minAge, int maxAge)
        {
            int childAge = DateTime.Now.Year - dateOfBirth.Year;
            return childAge >= minAge && childAge <= maxAge;
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Index", "Home");
        }

    }
}
