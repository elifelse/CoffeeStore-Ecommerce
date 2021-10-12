using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly IBasketService _basketService;

        public BasketController(IBasketViewModelService basketViewModelService, IBasketService basketService)
        {
            _basketViewModelService = basketViewModelService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketViewModelService.GetBasketViewModelAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            return Json(await _basketViewModelService.AddItemToBasketAsync(productId, quantity));
        }
    }
}
