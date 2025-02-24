using E_Shop.Application.ViewModels;

namespace E_Shop.Application.Services.ProductServices
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
