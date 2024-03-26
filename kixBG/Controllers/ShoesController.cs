using kixBG.Core.Contracts;
using kixBG.Core.Models.Shoes;
using kixBG.Extensions;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    public class ShoesController : Controller
    {
        private IShoesService shoesService;
        private ISellerService sellerService;

        public ShoesController(IShoesService shoesService, ISellerService sellerService)
        {
            this.shoesService = shoesService;
            this.sellerService = sellerService;
        }
        public async Task<IActionResult> All()
        {
            List<ShoeAllModel> allModel = await shoesService.GetAllAsync();

            return View(allModel);
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
            return RedirectToAction("Index", "Home");
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
    }
}
