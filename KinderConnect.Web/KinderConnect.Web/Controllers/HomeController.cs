using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.ViewModels.Home;
using KinderConnect.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

using static KinderConnect.Common.NotificationMessagesConstants;

using static KinderConnect.Common.GeneralApplicationConstants;

namespace KinderConnect.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService activityService;
        private readonly IBlogPostService blogPostService;
        private readonly ITeacherService teacherService;

        public HomeController(
             IActivityService activityService
            ,IBlogPostService blogPostService
            ,ITeacherService teacherService)
        {
            this.blogPostService = blogPostService;
            this.activityService = activityService;
            this.teacherService = teacherService;
            this.teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            try
            {
                var activitiesViewModel
                    = await activityService.GetThreeActivitiesAsync();

                var blogViewModel
                    = await blogPostService.GetThreeLastBlogPostsAsync();

                if (activitiesViewModel == null || blogViewModel == null)
                {
                    return BadRequest();
                }

                var indexViewModel = new IndexViewModel
                {
                    Activities = activitiesViewModel,
                    BlogPosts = blogViewModel
                };

                return View(indexViewModel);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }

        public async Task<IActionResult> About()
        {
            try
            {
                IEnumerable<AllTeacherViewModel> teachersForView
                    = await teacherService.GetTeachersForViewAsync();

                if (teachersForView == null)
                {
                    return BadRequest();
                }

                var aboutViewModel = new AboutViewModel
                {
                    Teachers = teachersForView
                };

                return View(aboutViewModel);
            }
            catch (Exception)
            {
                GeneralError();
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected Error occured. Please try again later :(";
            return RedirectToAction("Index", "Home");
        }
    }
}