﻿using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAsyncRepository<BasketItem> basketItemRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task AddItemToBasketAsync(int basketId, int productId, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException("Quantity must be a positive number.");

            var basket = await GetBasketWithItemsAsync(basketId);
            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                item = new BasketItem()
                {
                    BasketId = basketId,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.Items.Add(item);
            }

            await _basketRepository.UpdateAsync(basket);
        }

        private async Task<Basket> GetBasketWithItemsAsync(int basketId)
        {
            var spec = new BasketWithItemsSpecification(basketId);
            Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);

            if (basket == null)
                throw new BasketNotFoundException(basketId);

            return basket;
        }
    }
}
