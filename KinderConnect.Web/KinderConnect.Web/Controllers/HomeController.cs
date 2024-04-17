using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Models;
using KinderConnect.Web.ViewModels.Home;
using KinderConnect.Web.ViewModels.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            var activitiesViewModel
                = await activityService.GetAllActivitiesAsync();

            var blogViewModel
                = await blogPostService.GetThreeLastBlogPostsAsync();

            var indexViewModel = new IndexViewModel
            {
                Activities = activitiesViewModel,
                BlogPosts = blogViewModel
            };

            return View(indexViewModel);
        }

        public async Task<IActionResult> About()
        {
            IEnumerable<AllTeacherViewModel> teachersForView
                = await teacherService.GetTeachersForViewAsync();

            var aboutViewModel = new AboutViewModel
            {
                Teachers = teachersForView
            };

            return View(aboutViewModel);
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
    }
}