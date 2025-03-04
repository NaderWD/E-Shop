using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public interface ISpecificationService
    {
        #region Specification
        Task CreateSpecification(SpecCreateVM specVM);
        Task<List<SpecListVM>> GetAllSpecifications();
        Task<SpecCreateVM> GetSpecificationForEdit(int specId);
        Task UpdateSpecification(SpecCreateVM specVM);            
        Task DeleteSpecification(int specId);
        Task Save();
        #endregion                              

        #region CategorySpecification
        Task CreateCategorySpecification(CategorySpecVM categorySpec);
        Task<List<ProductCategories>> GetAllCategoriesList();
        Task UpdateCategorySpecifications(int specId, List<int> selectedCategoryIds);
        Task DeleteCategorySpecification(int specId);
        Task<bool> CheckCategorySpecExist(int categoryId);
        #endregion

        #region ProductSpecification
        Task AddSpecificationToProduct(AddSpecToProductVM addSpecVM);
        Task<List<SpecVM>> GetAvailableSpecificationsToAddProduct(int productId);
        Task<ProSpecDetailsFinalVM> GetSpecificationDetailByProductId(int productId);
        Task<ProSpecEditVM> GetProSpecVMForEdit(int proSpecId);
        Task UpdateProductSpecificationForProduct(ProSpecEditVM ProSpecVM);
        Task UpdateProductSpecifications(int productId, List<int> selectedSpecIds);
        Task DeleteProductSpecification(int proSpecId);
        #endregion
    }
}
