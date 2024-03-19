using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    public class ShoesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
