using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public interface ISpecificationService
    {
        Task CreateSpecification(SpecificationCreateVM createVM);
        Task AddCategoryToSpecification(int categoryId, int specId);
        Task AddSpecificationToProduct(ProductSpecificationAddVM specificationAddVM);
        Task<SpecificationDetailsVM> GetSpecificationsDetails(int specId);
        Task<SpecificationCreateVM> GetSpecificationCreateModel();
        Task<ProductSpecificationAddVM> GetProductSpecificationModel(int productId);
        Task<List<Specification>> GetAvailableSpecifications(int productId);
        Task<List<ProductCategoriesViewModel>> GetCategoriesForSpecification(int specId);
        Task<List<Specification>> GetSpecificationsForProduct(int productId);
        Task<List<Specification>> GetSpecificationsByCategoryId(int categoryId);
        Task RemoveProductSpecification(int productId, int specId);
        Task Save();
    }
}
