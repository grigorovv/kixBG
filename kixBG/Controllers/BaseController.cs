using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
