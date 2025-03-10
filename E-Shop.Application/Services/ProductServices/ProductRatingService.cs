using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Application.Services.ProductServices
{
    public class ProductRatingService(IProductRatingRepository _ratingRepository) : IProductRatingService
    {
        public async Task CreateProductRatingAsync(CreateProductRatingVM ratingVM)
        {
            var rating = new ProductRating
            {
                ProductId = ratingVM.ProductId,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                BuildQuality = ratingVM.BuildQuality,
                ValueForMoney = ratingVM.ValueForMoney,
                Innovation = ratingVM.Innovation,
                Features = ratingVM.Features,
                EaseOfUse = ratingVM.EaseOfUse,
                Design = ratingVM.Design,
                OverallRating = new[] {
                        ratingVM.BuildQuality,
                        ratingVM.ValueForMoney,
                        ratingVM.Innovation,
                        ratingVM.Features,
                        ratingVM.EaseOfUse,
                        ratingVM.Design
                        }.Average()
            };
            await _ratingRepository.AddProductRatingAsync(rating);
            await _ratingRepository.SaveAsync();
        }

        public async Task<ProductRatingSummaryVM> GetRatingSummaryByProductIdAsync(int productId)
        {
            var ratings = await _ratingRepository.GetRatingsByProductId(productId);
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

        public async Task<Product> GetProductById(int productId)
            => await _ratingRepository.GetProductById(productId);
    }
}
