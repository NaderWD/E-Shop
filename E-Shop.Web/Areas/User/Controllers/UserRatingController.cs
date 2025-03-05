using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserRatingController(IProductRatingService _ratingService) : UserBaseController
    {
        [HttpGet]
        public async Task<IActionResult> CreateRating(int productId)
        {
            var product = await _ratingService.GetProductById(productId);
            ViewBag.ProductName = product.Title;
            var model = new CreateProductRatingVM
            {
                ProductId = productId,
                OverallRating = 1,
                BuildQuality = 1,
                ValueForMoney = 1,
                Innovation = 1,
                Features = 1,
                EaseOfUse = 1,
                Design = 1
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating(CreateProductRatingVM model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(CreateRating), new { productId = model.ProductId });
            await _ratingService.CreateProductRatingAsync(model);
            return RedirectToAction("ProductDetail", "Product", new { productId = model.ProductId, area = "" });
        }
    }
}
