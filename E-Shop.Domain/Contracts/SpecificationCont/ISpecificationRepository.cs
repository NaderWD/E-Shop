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
        Task<bool> IsSpecificationExist(int specId);
        Task Save();
        #endregion



        #region CategorySpecification
        Task CreateCategorySpec(CategorySpecification categorySpec);
        Task<List<ProductCategories>> GetSubCategoryList();
        Task<List<ProductCategories>> GetCategoryListBySpecId(int specId);
        Task<List<Specification>> GetSpecListByCategoryId(int categoryId);
        Task<CategorySpecification> GetCategorySpecBySpecId(int specId);
        Task UpdateCategorySpec(CategorySpecification categorySpec);
        Task<bool> IsCategoryExist(int categoryId);
        #endregion



        #region ProductSpecification
        Task CreateProductSpec(ProductSpecification productSpec);
        Task<ProductSpecification> GetProductSpecBySpecId(int specId);
        Task<List<Specification>> GetSpecListByProductId(int productId);
        Task<Product> GetProductById(int productId);
        Task UpdateProductSpec(ProductSpecification productSpec);
        #endregion

    }
}
