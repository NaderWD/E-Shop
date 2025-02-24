using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Infra.Data.Repositories.SpecificationRepo
{
    public class SpecificationRepository : ISpecificationRepository
    {
        public Task Create(Specification specification)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int specificationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Specification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductSpecification> GetById(int specificationId)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(Specification specification)
        {
            throw new NotImplementedException();
        }
    }
}
