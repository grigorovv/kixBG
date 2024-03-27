using kixBG.Core.Contracts;
using kixBG.Core.Models.Clothes;
using kixBG.Core.Models.Seller;
using kixBG.Core.Models.Shoes;
using kixBG.Extensions;
using kixBG.Infrastructure.Data.Entities;
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
        private IClothesService clothesService;
        private IShoesService shoesService;

        public SellerController(ISellerService sellerService, ICityService cityService, IClothesService clothesService, IShoesService shoesService)
        {
            this.sellerService = sellerService;
            this.cityService = cityService;
            this.clothesService = clothesService;
            this.shoesService = shoesService;
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

        public async Task<IActionResult> Profile(int id)
        {
            Seller sellerToView = await sellerService.GetSellerById(id);
            if (sellerToView == null)
            {
                return BadRequest();
            }

            List<ShoeAllModel> sellerShoes = await shoesService.GetAllAsync();
            sellerShoes = sellerShoes.Where(s => s.SellerId == sellerToView.Id).ToList();

            List<ClothesAllModel> sellerClothes = await clothesService.GetAllAsync();
            sellerClothes = sellerClothes.Where(c => c.SellerId == sellerToView.Id).ToList();

            SellerProfileModel spm = new SellerProfileModel(sellerToView, sellerShoes, sellerClothes);

            return View(spm);
        }
    }
}
