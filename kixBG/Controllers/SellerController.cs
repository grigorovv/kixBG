using kixBG.Core.Contracts;
using kixBG.Core.Models.Seller;
using kixBG.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace kixBG.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        private ISellerService sellerService;
        private ICityService cityService;

        public SellerController(ISellerService sellerService, ICityService cityService)
        {
            this.sellerService = sellerService;
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await sellerService.ExistsById(User.Id()))
            {
                return BadRequest();
            }

            BecomeSellerFormModel model = new BecomeSellerFormModel();
            ViewBag.Cities = new SelectList(await cityService.GetAllAsync());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerFormModel model)
        {
            if (await sellerService.PhoneNumberTaken(model.PhoneNumber))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int cityId = cityService.FindByName(model.City);

            await sellerService.AddAsync(User.Id(), model.Name, model.PhoneNumber, cityId);
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
