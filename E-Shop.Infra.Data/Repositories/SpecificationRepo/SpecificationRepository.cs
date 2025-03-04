using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.SpecificationRepo
{
    public class SpecificationRepository(ShopDbContext _context) : ISpecificationRepository
    {
        #region Specification
        public async Task CreateSpec(Specification spec)
            => await _context.Specifications.AddAsync(spec);

        public async Task<List<Specification>> GetAllSpecs()
            => await _context.Specifications.Include(c => c.CategorySpecifications)
                                                               .Where(x => !x.IsDelete)
                                                               .OrderBy(y => y.Name)
                                                               .ToListAsync();

        public async Task<Specification> GetSpecById(int specId)
            => await _context.Specifications.Include(x => x.CategorySpecifications!)
                                                               .ThenInclude(xc => xc.Category)
                                                               .FirstOrDefaultAsync(x => x.Id == specId && !x.IsDelete);

        public async Task UpdateSpec(Specification spec)
            => _context.Specifications.Update(spec);

        public async Task DeleteSpecification(int specId)
            => _context.Remove(await GetSpecById(specId));

        public async Task Save()
            => await _context.SaveChangesAsync();
        #endregion

        #region CategorySpecification
        public async Task CreateCategorySpec(CategorySpecification categorySpec)
            => await _context.CategorySpecifications.AddAsync(categorySpec);

        public async Task<CategorySpecification> GetCategorySpecById(int catSpecId)
            => await _context.CategorySpecifications.FindAsync(catSpecId);

        public async Task<List<CategorySpecification>> GetCategorySpecListBySpecId(int specId)
            => await _context.CategorySpecifications.Where(x => x.SpecificationId == specId && !x.IsDelete).ToListAsync();

        public async Task<List<ProductCategories>> GetAllCategoryList()
                    => await _context.ProductCategories.Where(x => !x.IsDelete)
                                                       .Include(x => x.Parent)
                                                       .OrderBy(x => x.Name)
                                                       .ToListAsync();

        public async Task<List<ProductCategories>> GetCategoryListBySpecId(int specId)
            => await _context.CategorySpecifications.Where(x => x.SpecificationId == specId && !x.IsDelete)
                                                    .Include(x => x.Category)
                                                    .Select(x => x.Category)
                                                    .ToListAsync();

        public async Task<List<Specification>> GetSpecListByCategoryId(int categoryId)
            => await _context.CategorySpecifications.Where(x => x.CategoryId == categoryId && !x.IsDelete)
                                                    .Include(x => x.Specification)
                                                    .Select(x => x.Specification)
                                                    .ToListAsync();

        public async Task DeleteCategorySpec(int categorySpecId)
            => _context.CategorySpecifications.Remove(await GetCategorySpecById(categorySpecId));

        public async Task<bool> CheckCategorySpecExist(int categoryId)
        {
            var Check = await _context.CategorySpecifications.AnyAsync(x => x.CategoryId == categoryId && !x.IsDelete);
            if (!Check) return false;
            return true;
        }
        #endregion

        #region productSpecification
        public async Task CreateProductSpec(ProductSpecification productSpec)
            => await _context.ProductSpecifications.AddAsync(productSpec);

        public async Task<ProductSpecification> GetProductSpecById(int proSpecId)
            => await _context.ProductSpecifications.Include(x => x.Specification)
                                                                           .FirstOrDefaultAsync(x => x.Id == proSpecId);

        public async Task<List<ProductSpecification>> GetProductSpecListByProductId(int productId)
            => await _context.ProductSpecifications.Include(x => x.Product)
                                                                           .Include(s => s.Specification)
                                                                           .Where(x => x.ProductId == productId && !x.IsDelete).ToListAsync();

        public async Task<List<Specification>> GetSpecListByProductId(int productId)
            => await _context.ProductSpecifications.Where(x => x.ProductId == productId && !x.IsDelete)
                                                                                   .Include(c => c.Specification)
                                                                                   .Select(cv => cv.Specification!)
                                                                                   .ToListAsync();

        public async Task<Product> GetProductById(int productId)
            => await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && !x.IsDelete);

        public async Task UpdateProductSpec(ProductSpecification productSpec)
            => _context.ProductSpecifications.Update(productSpec);

        public async Task DeleteProductSpec(int productSpecId)
            => _context.ProductSpecifications.Remove(await GetProductSpecById(productSpecId));
        #endregion
    }
}
