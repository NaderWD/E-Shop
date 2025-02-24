using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.SpecificationModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.SpecificationRepo
{
    public class ProductSpecificationRepository(ShopDbContext _context) : IProductSpecificationRepository
    {
        public async Task Create(ProductSpecification productSpecification)
        {
            _context.ProductSpecifications.Add(productSpecification);
        }

        public async Task<List<ProductSpecification>> GetAll()
        {
            return await _context.ProductSpecifications.Include(x => x.Product)
                                                       .Include(y => y.Specification)
                                                       .ToListAsync();
        }

        public async Task<ProductSpecification> GetById(int productSpecificationId)
        {
            return await _context.ProductSpecifications.Include(x => x.Product)
                                                       .Include(y => y.Specification)
                                                       .FirstOrDefaultAsync(x => x.Id == productSpecificationId
                                                                                && !x.IsDelete);
        }

        public async Task Update(ProductSpecification productSpecification)
        {
            _context.ProductSpecifications.Update(productSpecification);
        }

        public async Task Delete(int productSpecificationId)
        {
            var productSpecification = await GetById(productSpecificationId);
            _context.ProductSpecifications.Remove(productSpecification);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
