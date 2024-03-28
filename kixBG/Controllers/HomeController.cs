using kixBG.Core.Contracts;
using kixBG.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kixBG.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISellerService sellerService;

        public HomeController(ILogger<HomeController> logger, ISellerService sellerService)
        {
            _logger = logger;
            this.sellerService = sellerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListingCategory()
        {
            if (!await sellerService.ExistsById(User.Id()))
            {
                return View("NotASeller");
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Shop()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Faq()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            else if (statusCode == 401)
            {
                return View("Error401");
            }
            else if (statusCode == 404)
            {
                return View("Error404");
            }
            else
            {
                return View();
            }
        }
    }
}