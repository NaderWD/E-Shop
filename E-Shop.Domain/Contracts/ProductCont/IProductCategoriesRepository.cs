using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Contracts.ProductCont
{
    public interface IProductCategoriesRepository
    {
        List<ProductCategories> GetAll();
        ProductCategories GetProductCategoryById(int Id);
        bool CreateProductCategory(ProductCategories model);
        bool UpdateProductCategory(ProductCategories model);
        bool Save();

        Task<bool> Exist(int categoryId);
        Task<List<ProductCategories>> GetAllSubCategories();
    }
}
