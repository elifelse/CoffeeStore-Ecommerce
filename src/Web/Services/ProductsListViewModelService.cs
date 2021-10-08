using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class ProductsListViewModelService : IProductsListViewModelService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        public ProductsListViewModelService(IAsyncRepository<Product> productRepository, IAsyncRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductsListViewModel> GetProductsListViewModelAsync(int? categoryId, int page)
        {
            var specProducts = new ProductsFilterSpecification(categoryId);
            var totalItemsCount = await _productRepository.CountAsync(specProducts);
            var totalPagesCount = (int)Math.Ceiling((decimal)totalItemsCount / Constants.ITEMS_PER_PAGE);

            var specPaginatedProducts = new ProductsFilterPaginatedSpecification(
                categoryId, (page - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE);
            var products = await _productRepository.ListAsync(specPaginatedProducts);

            var vm = new ProductsListViewModel()
            {
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    PictureUri = p.PictureUri
                }).ToList(),
                Categories = await GetCategoriesAsync(),
                CategoryId = categoryId,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    Page = page,
                    TotalItems = totalItemsCount,
                    TotalPages = totalPagesCount,
                    ItemsOnPage = products.Count,
                    HasPrevius = page > 1,
                    HasNext = page < totalPagesCount
                }
            };

            return vm;
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            return (await _categoryRepository.ListAllAsync()).Select(
                c => new SelectListItem(c.CategoryName, c.Id.ToString())
                );
        }
    }
}
