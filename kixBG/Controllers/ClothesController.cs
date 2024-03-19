using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    public class ClothesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }

        public IActionResult Sports()
        {
            return View();
        }
    }
}
