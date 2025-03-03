using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Application.Services.ProductServices
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IProductRatingRepository _ratingRepository;

        public ProductRatingService(IProductRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task CreateProductRatingAsync(CreateProductRatingVM ratingVM)
        {
            var rating = new ProductRating
            {
                ProductId = ratingVM.ProductId,
                RaterName = ratingVM.RaterName,
                OverallRating = ratingVM.OverallRating,
                BuildQuality = ratingVM.BuildQuality,
                ValueForMoney = ratingVM.ValueForMoney,
                Innovation = ratingVM.Innovation,
                Features = ratingVM.Features,
                EaseOfUse = ratingVM.EaseOfUse,
                Design = ratingVM.Design
            };
            await _ratingRepository.AddProductRatingAsync(rating);
            await _ratingRepository.SaveAsync();
        }

        public async Task<ProductRatingSummaryVM> GetRatingSummaryByProductIdAsync(int productId)
        {
            var ratings = _ratingRepository.GetRatingsByProductId(productId);
            var count = await ratings.CountAsync();
            if (count == 0) return new ProductRatingSummaryVM { RatingCount = 0 };
            return new ProductRatingSummaryVM
            {
                OverallRating = await ratings.AverageAsync(r => r.OverallRating),
                BuildQuality = await ratings.AverageAsync(r => r.BuildQuality),
                ValueForMoney = await ratings.AverageAsync(r => r.ValueForMoney),
                Innovation = await ratings.AverageAsync(r => r.Innovation),
                Features = await ratings.AverageAsync(r => r.Features),
                EaseOfUse = await ratings.AverageAsync(r => r.EaseOfUse),
                Design = await ratings.AverageAsync(r => r.Design),
                RatingCount = count
            };
        }
    }
}
