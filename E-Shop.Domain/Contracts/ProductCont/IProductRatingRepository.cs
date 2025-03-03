using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Contracts.ProductCont
{
    public interface IProductRatingRepository
    {
        Task AddProductRatingAsync(ProductRating rating);
        IQueryable<ProductRating> GetRatingsByProductId(int productId);
        Task SaveAsync();
    }
}
