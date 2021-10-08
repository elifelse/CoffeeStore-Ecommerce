using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsListViewModelService _productsListViewModelService;

        public ProductController(IProductsListViewModelService productsListViewModelService)
        {
            _productsListViewModelService = productsListViewModelService;
        }
        public async Task<IActionResult> Index(int? categoryId, int page = 1)
        {
            return View(await _productsListViewModelService.GetProductsListViewModelAsync(categoryId, page));
        }
    }
}
