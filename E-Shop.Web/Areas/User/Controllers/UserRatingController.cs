using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserRatingController(IProductRatingService _ratingService) : UserBaseController
    {

        public IActionResult CreateRating(int productId)
        {
            var model = new CreateProductRatingVM { ProductId = productId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRating(CreateProductRatingVM model)
        {
            if (!ModelState.IsValid) return View(model);
            await _ratingService.CreateProductRatingAsync(model);
            return RedirectToAction("ProductDetail", "Product", new { id = model.ProductId });
        }
    }
}
