using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public interface ISpecificationService
    {
        Task AddCategoryToSpec(int categoryId, int specId);
        Task CreateSpec(SpecCreateVM createVM);
        Task AddSpecToProduct(ProductSpecAddVM specAddVM);
        Task<List<SpecListVM>> GetAllSpecs();
        Task<SpecDetailsVM> GetSpecDetails(int specId);
        Task<SpecCreateVM> GetSpecByIdForEditProduct(int specId);
        Task<SpecCreateVM> GetSpecCreateModel();
        Task<List<Specification>> GetSpecListByProductId(int productId);
        Task<List<Specification>> GetAvailableSpecs(int productId);
        Task<ProductSpecAddVM> GetProductSpecModel(int productId);
        Task<ProductSpecification> GetProductSpec(int productId, int specId);
        Task UpdateSpec(SpecCreateVM specUpdate);
        Task UpdateProductSpec(UpdateProductSpecVM productSpecUpdate);
        Task DeleteSpec(int specId);          
        Task DeleteCategorySpec(int specId);
        Task DeleteProductSpec(int specId);
        Task Save();
    }
}
