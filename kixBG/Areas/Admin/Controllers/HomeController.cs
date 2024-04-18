using Microsoft.AspNetCore.Mvc;

namespace kixBG.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
