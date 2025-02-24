using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.SpecificationModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.SpecificationRepo
{
    public class SpecificationRepository(ShopDbContext _context) : ISpecificationRepository
    {
        public async Task Create(Specification specification)
        {
            await _context.Specifications.AddAsync(specification);
        }

        public async Task<List<Specification>> GetAll()
        {
            return await _context.Specifications.ToListAsync();
        }

        public async Task<Specification> GetById(int specificationId)
        {
            return await _context.Specifications.FirstOrDefaultAsync(x => x.Id == specificationId && !x.IsDelete);
        }

        public async Task Update(Specification specification)
        {
            _context.Specifications.Update(specification);
        }

        public async Task Delete(int specificationId)
        {
            var specification = await GetById(specificationId);
            _context.Specifications.Remove(specification);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
