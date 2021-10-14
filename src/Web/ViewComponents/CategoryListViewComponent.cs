using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoryListViewComponent(IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new CategoryListViewModel(await _categoryRepository.ListAllAsync()));
        }
    }
}
