using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
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
        List<SelectListitem> GetSelectItems();
        CreatProductCategoryViewModel GetUpdateModel(int Id);
        ProductCategoriesViewModel GetProductCategoryById(int Id);
        bool CreateproductCategory(CreatProductCategoryViewModel model);
        bool UpdateproductCategory(CreatProductCategoryViewModel model , bool IsDuplicatedCheck);
        bool DeleteproductCategory(int Id);
    }
}
