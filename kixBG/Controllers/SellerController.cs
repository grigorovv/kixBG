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

            BecomeSellerFormModel model = new BecomeSellerFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerFormModel model)
        {
            if (await service.PhoneNumberTaken(model.PhoneNumber))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddAsync(User.Id(), model.Name, model.PhoneNumber, model.CityId);
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
