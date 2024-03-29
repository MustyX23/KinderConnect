using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Models;
using KinderConnect.Web.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KinderConnect.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityService activityService;
        private readonly IBlogPostService blogPostService;
        public HomeController(IActivityService activityService
            , IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
            this.activityService = activityService;
        }

        public async Task<IActionResult> Index()
        {
            var activitiesViewModel
                = await activityService.GetAllActivitiesAsync();

            var blogViewModel
                = await blogPostService.GetThreeBlogPostsAsync();

            var indexViewModel = new IndexViewModel
            {
                Activities = activitiesViewModel,
                BlogPosts = blogViewModel
            };

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}