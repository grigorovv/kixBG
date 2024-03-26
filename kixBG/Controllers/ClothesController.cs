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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Clothe clotheToEdit = await clothesService.GetItemByIdAsync(id);

            if (clotheToEdit == null)
            {
                return NotFound();
            }
            if (clotheToEdit.SellerId != await sellerService.GetSellerIdByUserId(User.Id()))
            {
                return Unauthorized();
            }

            ClothesFormModel formModel = new ClothesFormModel
            {
                Id = id,
                ImageURL = clotheToEdit.ImageURL,
                Model = clotheToEdit.Model,
                Condition = clotheToEdit.Condition,
                Price = clotheToEdit.Price,
                Size = clotheToEdit.Size,
                Brands = await clothesService.AllBrandsAsync(),
                Categories = await clothesService.AllCategoriesAsync()
            };
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClothesFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            Clothe clotheToEdit = await clothesService.GetItemByIdAsync(formModel.Id);

            clotheToEdit.ImageURL = formModel.ImageURL;
            clotheToEdit.Model = formModel.Model;
            clotheToEdit.Condition = formModel.Condition;
            clotheToEdit.Price = formModel.Price;
            clotheToEdit.Size = formModel.Size;
            clotheToEdit.BrandId = formModel.BrandId;
            clotheToEdit.CategoryId = formModel.CategoryId;

            clothesService.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
