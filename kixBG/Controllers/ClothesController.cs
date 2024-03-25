using kixBG.Core.Contracts;
using kixBG.Core.Models.Clothes;
using kixBG.Extensions;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    public class ClothesController : Controller
    {
        private IClothesService clothesService;
        private ISellerService sellerService;

        public ClothesController(IClothesService clothesService, ISellerService sellerService)
        {
            this.clothesService = clothesService;
            this.sellerService = sellerService;
        }

        public async Task<IActionResult> All()
        {
            List<ClothesAllModel> allModel = await clothesService.GetAllAsync();

            return View(allModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ClothesFormModel model = new ClothesFormModel();

            model.Categories = await clothesService.AllCategoriesAsync();
            model.Brands = await clothesService.AllBrandsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClothesFormModel modelToBind)
        {
            if (ModelState.IsValid == false)
            {
                modelToBind.Categories = await clothesService.AllCategoriesAsync();
                modelToBind.Brands = await clothesService.AllBrandsAsync();

                return View(modelToBind);
            }

            Clothe clotheToAdd = new Clothe();
            clotheToAdd.SellerId = await sellerService.GetSellerIdByUserId(User.Id());
            clotheToAdd.ImageURL = modelToBind.ImageURL;
            clotheToAdd.Model = modelToBind.Model;
            clotheToAdd.CategoryId = modelToBind.CategoryId;
            clotheToAdd.BrandId = modelToBind.BrandId;
            clotheToAdd.Condition = modelToBind.Condition;
            clotheToAdd.Size = modelToBind.Size;
            clotheToAdd.Price = modelToBind.Price;

            clothesService.AddAsync(clotheToAdd);

            return RedirectToAction("Index", "Home");
        }
    }
}
