using kixBG.Core.Contracts;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kixBG.Areas.Admin.Controllers
{
    public class SellersController : AdminController
    {
        private IRepository repository;
        private IClothesService clothesService;
        private IShoesService shoesService;

        public SellersController(IRepository repository, IClothesService cs, IShoesService ss)
        {
            this.repository = repository;
            clothesService = cs;
            shoesService = ss;
        }

        public IActionResult All()
        {
            var sellers = repository.AllReadOnly<Seller>().ToList();

            ViewBag.ShoesService = shoesService;
            ViewBag.ClothesService = clothesService;
            return View(sellers);
        }
    }
}
