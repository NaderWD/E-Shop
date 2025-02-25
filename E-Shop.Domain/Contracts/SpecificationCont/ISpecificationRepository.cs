using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Domain.Contracts.SpecificationCont
{
    public interface ISpecificationRepository
    {
        Task Create(Specification spec);         
        Task CreateCategorySpecification(CategorySpecification categorySpec);
        Task CreateProductSpecification(ProductSpecification productSpec);
        Task<Specification> GetSpecificationById(int specId);
        Task<List<ProductCategories>> GetCategoriesForSpecification(int specId);
        Task RemoveProductSpecification(int productId, int specId);
        Task<List<Specification>> GetSpecificationsForProduct(int productId);
        Task<List<Specification>> GetSpecificationsByCategoryId(int categoryId);
        Task Save();
    }
}
