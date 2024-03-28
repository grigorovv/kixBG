using kixBG.Core.Contracts;
using kixBG.Core.Models.Brands;
using kixBG.Core.Models.Shoes;
using kixBG.Extensions;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace kixBG.Controllers
{
    public class ShoesController : BaseController
    {
        private IShoesService shoesService;
        private ISellerService sellerService;

        public ShoesController(IShoesService shoesService, ISellerService sellerService)
        {
            this.shoesService = shoesService;
            this.sellerService = sellerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(string? brandFilter,string? searchString, int? page)
        {
            List<ShoeAllModel> allModel = await shoesService.GetAllAsync();
            int pageSize = 3;
            int pagenumber = page ?? 1;

            IEnumerable<BrandsServiceModel> brands = await shoesService.AllBrandsAsync();

            if (!string.IsNullOrEmpty(brandFilter))
            {
                int brandId = brands.Where(b => b.Name.ToLower() == brandFilter.ToLower())
                                           .Select(b => b.Id).First();

                allModel = allModel.Where(s => s.BrandId == brandId)
                                   .ToList();
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                allModel = allModel.Where(s => s.Model.ToLower().Contains(searchString.ToLower()))
                                   .ToList();
            }

            ViewBag.Brands = brands;

            return View(allModel.ToPagedList(pagenumber, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ShoeFormModel formModel = new ShoeFormModel()
            {
                Brands = await shoesService.AllBrandsAsync()
            };
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShoeFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            Shoe shoeToAdd = new Shoe();
            shoeToAdd.SellerId = await sellerService.GetSellerIdByUserId(User.Id());
            shoeToAdd.ImageURL = formModel.ImageURL;
            shoeToAdd.BrandId = formModel.BrandId;
            shoeToAdd.Model = formModel.Model;
            shoeToAdd.Condition = formModel.Condition;
            shoeToAdd.Size = formModel.Size;
            shoeToAdd.Price = formModel.Price;

            shoesService.AddAsync(shoeToAdd);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Shoe shoeToEdit = await shoesService.GetShoeByIdAsync(id);

            if (shoeToEdit == null)
            {
                return NotFound();
            }
            if (shoeToEdit.SellerId != await sellerService.GetSellerIdByUserId(User.Id()))
            {
                return Unauthorized();
            }

            ShoeFormModel formModel = new ShoeFormModel
            {
                Id = id,
                BrandId = shoeToEdit.BrandId,
                ImageURL = shoeToEdit.ImageURL,
                Model = shoeToEdit.Model,
                Condition = shoeToEdit.Condition,
                Price = shoeToEdit.Price,
                Size = shoeToEdit.Size,
                Brands = await shoesService.AllBrandsAsync()
            };
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ShoeFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            Shoe shoeToEdit = await shoesService.GetShoeByIdAsync(formModel.Id);

            shoeToEdit.ImageURL = formModel.ImageURL;
            shoeToEdit.Model = formModel.Model;
            shoeToEdit.Condition = formModel.Condition;
            shoeToEdit.Price = formModel.Price;
            shoeToEdit.Size = formModel.Size;
            shoeToEdit.BrandId = formModel.BrandId;

            shoesService.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Shoe shoeToCheck = await shoesService.GetShoeByIdAsync(id);

            if (shoeToCheck == null)
            {
                return NotFound();
            }

            IEnumerable<BrandsServiceModel> brands = await shoesService.AllBrandsAsync();
            string brandName = brands.Where(b => b.Id == shoeToCheck.BrandId)
                .Select(b => b.Name)
                .First();

            ShoeDetailModel detailModel = new ShoeDetailModel()
            {
                Id = id,
                ImageURL = shoeToCheck.ImageURL,
                Model = shoeToCheck.Model,
                Brand = brandName,
                Condition = shoeToCheck.Condition,
                Size = shoeToCheck.Size,
                Price = shoeToCheck.Price,
                SellerId = shoeToCheck.SellerId,
                SellerUserId = await sellerService.GetUserIdBySellerId(shoeToCheck.SellerId)
            };

            return View(detailModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Shoe clotheToDelete = await shoesService.GetShoeByIdAsync(id);
            if (clotheToDelete.SellerId != await sellerService.GetSellerIdByUserId(User.Id()))
            {
                return Unauthorized();
            }
            shoesService.DeleteItem(clotheToDelete);

            return RedirectToAction(nameof(All));
        }
    }
}
