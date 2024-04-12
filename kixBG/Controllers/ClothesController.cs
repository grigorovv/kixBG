using kixBG.Core.Contracts;
using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Clothes;
using kixBG.Core.Models.ClothesCategories;
using kixBG.Extensions;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace kixBG.Controllers
{
    public class ClothesController : BaseController
    {
        private IClothesService clothesService;
        private ISellerService sellerService;

        public ClothesController(IClothesService clothesService, ISellerService sellerService)
        {
            this.clothesService = clothesService;
            this.sellerService = sellerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(string? categoryFilter, string? searchString, int? page)
        {
            List<ClothesAllModel> allModel = await clothesService.GetAllAsync();
            int pageSize = 3;
            int pagenumber = page ?? 1;
            IEnumerable<ClothesCategoryServiceModel> categories = await clothesService.AllCategoriesAsync();

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                int categoryId = categories.Where(cc => cc.Name.ToLower() == categoryFilter.ToLower())
                                           .Select(cc => cc.Id).First();

                allModel = allModel.Where(c => c.CategoryId == categoryId)
                                   .ToList();
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                allModel = allModel.Where(c => c.Model.ToLower().Contains(searchString.ToLower()))
                                   .ToList();
            }

            ViewBag.Categories = categories;
            return View(allModel.ToPagedList(pagenumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!await sellerService.ExistsById(User.Id()))
            {
                return Unauthorized();
            }

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

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Clothe clotheToEdit = await clothesService.GetItemByIdAsync(id);

            if (clotheToEdit == null)
            {
                return NotFound();
            }

            int currentSellerId = await sellerService.GetSellerIdByUserId(User.Id());

            if ((currentSellerId == 0 || clotheToEdit.SellerId != currentSellerId) && !User.IsAdmin())
            {
                return Unauthorized();
            }

            ClothesFormModel formModel = new ClothesFormModel
            {
                Id = id,
                BrandId = clotheToEdit.BrandId,
                CategoryId = clotheToEdit.CategoryId,
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Clothe clotheToCheck = await clothesService.GetItemByIdAsync(id);

            if (clotheToCheck == null)
            {
                return NotFound();
            }


            IEnumerable<BrandsServiceModel> brands = await clothesService.AllBrandsAsync();
            string brandName = brands.Where(b => b.Id == clotheToCheck.BrandId)
                .Select(b => b.Name)
                .First();

            IEnumerable<ClothesCategoryServiceModel> categories = await clothesService.AllCategoriesAsync();
            string categoryName = categories.Where(c => c.Id == clotheToCheck.CategoryId)
                .Select(b => b.Name)
                .First();

            ClothesDetailModel detailModel = new ClothesDetailModel()
            {
                Id = id,
                ImageURL = clotheToCheck.ImageURL,
                Model = clotheToCheck.Model,
                Brand = brandName,
                Category = categoryName,
                Condition = clotheToCheck.Condition,
                Size = clotheToCheck.Size,
                Price = clotheToCheck.Price,
                SellerUserId = await sellerService.GetUserIdBySellerId(clotheToCheck.SellerId),
                SellerId = clotheToCheck.SellerId
            };

            return View(detailModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Clothe clotheToDelete = await clothesService.GetItemByIdAsync(id);
            if (clotheToDelete.SellerId != await sellerService.GetSellerIdByUserId(User.Id()) && !User.IsAdmin())
            {
                return Unauthorized();
            }
            clothesService.DeleteItem(clotheToDelete);

            return RedirectToAction(nameof(All));
        }
    }
}
