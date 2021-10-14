using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel(List<Category> listCategory)
        {
            Categories = listCategory;
        }

        public int? Id { get; set; }
        public List<Category> Categories { get; set; }
    }
}
