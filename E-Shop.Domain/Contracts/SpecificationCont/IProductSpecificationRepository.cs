using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Domain.Contracts.SpecificationCont
{
    public interface IProductSpecificationRepository
    {
        Task Create(ProductSpecification productSpecification);
        Task<List<ProductSpecification>> GetAll();
        Task<ProductSpecification> GetById(int productSpecificationId);
        Task Update(ProductSpecification productSpecification);
        Task Delete(int productSpecificationId);
        Task Save();   
    }
}
