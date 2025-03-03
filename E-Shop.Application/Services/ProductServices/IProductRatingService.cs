using E_Shop.Application.ViewModels.ProductsViewModel;

namespace E_Shop.Application.Services.ProductServices
{
    public interface IProductRatingService
    {
        Task CreateProductRatingAsync(CreateProductRatingVM ratingVM);
        Task<ProductRatingSummaryVM> GetRatingSummaryByProductIdAsync(int productId);
    }
}
