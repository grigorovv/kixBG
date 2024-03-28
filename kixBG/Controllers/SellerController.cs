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
    public class SellerController : BaseController
    {
        private ISellerService sellerService;
        private ICityService cityService;
        private IClothesService clothesService;
        private IShoesService shoesService;
        private ICountryService countryService;

        public SellerController(ISellerService sellerService, 
            ICityService cityService, 
            IClothesService clothesService, 
            IShoesService shoesService, 
            ICountryService countryService)
        {
            this.sellerService = sellerService;
            this.cityService = cityService;
            this.clothesService = clothesService;
            this.shoesService = shoesService;
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await sellerService.ExistsById(User.Id()))
            {
                return View("AlreadySeller");
            }

            BecomeSellerFormModel model = new BecomeSellerFormModel();
            List<City> cities = await cityService.GetAllAsync();

            ViewBag.Cities = new SelectList(cities.Select(c => c.Name).ToList());

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

        public async Task<IActionResult> Profile(string? userId, int id)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                id = await sellerService.GetSellerIdByUserId(userId);
            }
            Seller sellerToView = await sellerService.GetSellerById(id);
            if (sellerToView == null)
            {
                return BadRequest();
            }

            List<ShoeAllModel> sellerShoes = await shoesService.GetAllAsync();
            sellerShoes = sellerShoes.Where(s => s.SellerId == sellerToView.Id).ToList();

            List<ClothesAllModel> sellerClothes = await clothesService.GetAllAsync();
            sellerClothes = sellerClothes.Where(c => c.SellerId == sellerToView.Id).ToList();

            var cities = await cityService.GetAllAsync();
            City city = cities.Where(c => c.Id == sellerToView.CityId)
                                       .First();

            var country = await countryService.GetCountryById(city.CountryId);

            SellerProfileModel spm = new SellerProfileModel(sellerToView, sellerShoes, sellerClothes, city.Name, country.Name);

            return View(spm);
        }
    }
}
