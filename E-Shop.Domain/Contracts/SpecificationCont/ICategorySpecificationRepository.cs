using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Domain.Contracts.SpecificationCont
{
    public interface ICategorySpecificationRepository
    {
        Task Create(CategorySpecification categorySpecification);
        Task<List<CategorySpecification>> GetAll();
        Task<CategorySpecification> GetById(int categorySpecificationId);
        Task Update(CategorySpecification categorySpecification);
        Task Delete(int categorySpecificationId);
        Task Save();
    }
}
