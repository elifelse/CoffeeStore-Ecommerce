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
        public async Task<ProductsListViewModel> GetProductsListViewModelAsync(int? categoryId)
        {
            var specProducts = new ProductsFilterSpecification(categoryId);
            var products = await _productRepository.ListAsync(specProducts);

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
                CategoryId = categoryId
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
