using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.SpecificationRepo
{
    public class SpecificationRepository(ShopDbContext _context) : ISpecificationRepository
    {
        public async Task CreateCategorySpecification(CategorySpecification categorySpec)
            => await _context.CategorySpecifications.AddAsync(categorySpec);

        public async Task CreateProductSpecification(ProductSpecification productSpec)
            => await _context.ProductSpecifications.AddAsync(productSpec);

        public async Task Create(Specification spec)
            => await _context.Specifications.AddAsync(spec);

        public async Task<Specification> GetSpecificationById(int specId)
            => await _context.Specifications.Include(x => x.CategorySpecifications)
                                            .FirstOrDefaultAsync(x => x.Id == specId && !x.IsDelete);

        public async Task<List<ProductCategories>> GetCategoriesForSpecification(int specId)
            => await _context.CategorySpecifications.Where(x => x.Id == specId && !x.IsDelete)
                                                    .Include(x => x.Category)
                                                    .Select(x => x.Category)
                                                    .ToListAsync();

        public async Task<List<Specification>> GetSpecificationsByCategoryId(int categoryId)
            => await _context.CategorySpecifications.Where(x => x.CategoryId == categoryId && !x.IsDelete)
                                                    .Include(x => x.Specification)
                                                    .Select(x => x.Specification)
                                                    .ToListAsync();

        public async Task<List<Specification>> GetSpecificationsForProduct(int productId)
            => await _context.Specifications.Include(x => x.ProductSpecifications)
                                            .Where(x => x.ProductSpecificationId == productId
                                                    && !x.IsDelete)
                                            .ToListAsync();

        public async Task RemoveProductSpecification(int productId, int specId)
            => _context.ProductSpecifications.Remove(await _context.ProductSpecifications
                                             .FirstOrDefaultAsync(x => x.ProductId == productId
                                                                    && x.SpecificationId == specId));

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
