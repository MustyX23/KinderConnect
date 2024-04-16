using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static KinderConnect.Common.GeneralApplicationConstants;

namespace KinderConnect.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
    }
}
