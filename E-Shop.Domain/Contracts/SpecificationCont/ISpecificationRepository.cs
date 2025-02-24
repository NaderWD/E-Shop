using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Domain.Contracts.SpecificationCont
{
    public interface ISpecificationRepository
    {
        Task Create(Specification specification);
        Task<List<Specification>> GetAll();
        Task<ProductSpecification> GetById(int specificationId);
        Task Update(Specification specification);
        Task Delete(int specificationId);
        Task Save();
    }
}
