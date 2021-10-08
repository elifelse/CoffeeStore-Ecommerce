using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IProductsListViewModelService
    {
        Task<ProductsListViewModel> GetProductsListViewModelAsync(int? categoryId);
    }
}
