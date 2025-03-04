using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class ProductRatingSummaryViewComponent(IProductRatingService _ratingService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var summary = await _ratingService.GetRatingSummaryByProductIdAsync(productId);
            return View("ProductRatingSummary", summary);
        }
    }
}
