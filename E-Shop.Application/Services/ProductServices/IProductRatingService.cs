using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductRatingService
    {
        Task CreateProductRatingAsync(CreateProductRatingVM ratingVM);
        Task<ProductRatingSummaryVM> GetRatingSummaryByProductIdAsync(int productId);
        Task<Product> GetProductById(int productId);
    }
}
