using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Domain.Contracts.SpecificationCont
{
    public interface ISpecificationRepository
    {

        #region Specification
        Task CreateSpec(Specification spec);
        Task<List<Specification>> GetAllSpecs();
        Task<Specification> GetSpecById(int specId);
        Task UpdateSpec(Specification spec);
        Task Save();
        #endregion



        #region CategorySpecification
        Task CreateCategorySpec(CategorySpecification categorySpec);
        Task<List<CategorySpecification>> GetCategorySpecListBySpecId(int specId);
        Task<CategorySpecification> GetCategorySpecByCategoryId(int categoryId);
        Task<List<ProductCategories>> GetAllCategoryList();
        Task<List<ProductCategories>> GetCategoryListBySpecId(int specId);
        Task<List<Specification>> GetSpecListByCategoryId(int categoryId);
        Task UpdateCategorySpec(CategorySpecification categorySpec);
        Task<bool> CheckCategorySpecExist(int categoryId); 
        #endregion



        #region ProductSpecification
        Task CreateProductSpec(ProductSpecification productSpec);
        Task<ProductSpecification> GetProductSpecBySpecId(int specId);
        Task<List<ProductSpecification>> GetProductSpecListBySpecId(int specId);   
        Task<List<ProductSpecification>> GetProductSpecListByProductId(int specId);
        Task<List<Specification>> GetSpecListByProductId(int productId);
        Task<Product> GetProductById(int productId);
        Task UpdateProductSpec(ProductSpecification productSpec);
        Task<bool> CheckProductSpecExist(int specId);
        #endregion

    }
}
