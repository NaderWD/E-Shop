using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Infra.Data.Repositories.ProductRepo
{
    public class ProductRatingRepository(ShopDbContext _context) : IProductRatingRepository
    {
        public async Task AddProductRatingAsync(ProductRating rating)
            => await _context.ProductRatings.AddAsync(rating);

        public async Task<Product> GetProductById(int productId)
            => await _context.Products.FindAsync(productId);

        public async Task<IQueryable<ProductRating>> GetRatingsByProductId(int productId)
            => _context.ProductRatings.Where(r => r.ProductId == productId && !r.IsDelete);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
