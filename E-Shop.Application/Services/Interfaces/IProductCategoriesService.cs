using E_Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IProductCategoriesService
    {
        List<ProductCategoriesViewModel> GetAll();
        CreatProductCategoryViewModel GetCreatModel();
        bool CreateproductCategory(CreatProductCategoryViewModel model);
    }
}
