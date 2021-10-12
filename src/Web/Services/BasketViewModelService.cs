using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;
 
namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IBasketService _basketService;

        public BasketViewModelService(IHttpContextAccessor httpContextAccessor, IAsyncRepository<Basket> basketRepository, IBasketService basketService)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketRepository = basketRepository;
            _basketService = basketService;
        }

        public async Task<BasketItemAddedViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            // Get or create basket id
            var basketId = await GetOrCreateBasketIdAsync();

            // Add item to the basket
            await _basketService.AddItemToBasketAsync(basketId, productId, quantity);

            // Return items count int the basket
            return new BasketItemAddedViewModel()
            {
                ItemsCount = await _basketService.BasketItemsCountAsync(basketId)
            };
        }

        public async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            var basketId = await GetBasketIdAsync();
            var vm = new BasketViewModel();
            if (!basketId.HasValue) return vm;


            var spec = new BasketWithItemsAndProductsSpecification(basketId.Value);
            var basket = await _basketRepository.FirstOrDefaultAsync(spec);
            vm.Items = basket.Items.Select(x => new BasketItemViewModel()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                PictureUri = x.Product.PictureUri,
                UnitPrice = x.Product.Price,
                Quantity = x.Quantity
            }).ToList();
            vm.TotalPrice = vm.Items.Sum(x => x.Quantity * x.UnitPrice);

            return vm;
        }

        private async Task<int?> GetBasketIdAsync()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var anonymousUserId = _httpContextAccessor.HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];
            var buyerId = userId ?? anonymousUserId;

            if (buyerId != null)
            {
                var spec = new BasketSpecification(buyerId);
                var basket = await _basketRepository.FirstOrDefaultAsync(spec);

                if (basket != null)
                    return basket.Id;
            }

            return null;
        }

        public async Task<int> GetOrCreateBasketIdAsync()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                var spec = new BasketSpecification(userId);
                Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);

                if (basket != null) return basket.Id;

                return (await CreateBasketIdAsync(userId)).Id;
            }

            var anonymousUserId = _httpContextAccessor.HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];
            if (!string.IsNullOrEmpty(anonymousUserId))
            {
                var spec = new BasketSpecification(anonymousUserId);
                Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);
                return basket.Id;
            }

            anonymousUserId = Guid.NewGuid().ToString();
            _httpContextAccessor.HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, anonymousUserId, new CookieOptions() { Expires = DateTime.Now.AddMonths(1), IsEssential = true });


            return (await CreateBasketIdAsync(anonymousUserId)).Id;
        }

        private async Task<Basket> CreateBasketIdAsync(string buyerId)
        {
            Basket basket = new Basket()
            {
                BuyerId = buyerId
            };

            return await _basketRepository.AddAsync(basket);
        }
    }
}
