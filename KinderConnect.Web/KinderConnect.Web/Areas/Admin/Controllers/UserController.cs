using KinderConnect.Services.Data.Interfaces;
using KinderConnect.Web.Infrastructure.Extensions;
using KinderConnect.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using static KinderConnect.Common.GeneralApplicationConstants;
using static KinderConnect.Common.NotificationMessagesConstants;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            try
            {
                if (!User.IsAdmin())
                {
                    return Unauthorized();
                }
                IEnumerable<UserViewModel> users =
                    this.memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);
                if (users == null)
                {
                    users = await this.userService.AllAsync();

                    MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan
                            .FromMinutes(UsersCacheDurationMinutes));

                    this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
                }

                return View(users);
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
