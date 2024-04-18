using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static kixBG.Infrastructure.Data.Constants.AdminConstants;

namespace kixBG.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminController : Controller
    {
    }
}
