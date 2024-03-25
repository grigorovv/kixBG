using kixBG.Core.Contracts;
using kixBG.Core.Models.Seller;
using kixBG.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace kixBG.Controllers
{
    public class SellerController : Controller
    {
        private ISellerService service;

        public SellerController(ISellerService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await service.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerFormModel model)
        {
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
