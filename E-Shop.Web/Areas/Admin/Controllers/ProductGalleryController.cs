using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductGalleryController(IProductGalleryService productGalleryService) : AdminBaseController
    {
        public IActionResult ProductGalleryIndex(int productId)
        {
            var content = productGalleryService.GetGalleryByProductId(productId);
            return View(content);
        }
        #region AddGallery

        public IActionResult AddProductGallery(int ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }

        [HttpPost]
        public IActionResult AddProductGallery(AddProductGalleryViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var result = productGalleryService.CreateGallery(model);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    return RedirectToAction("ProductIndex");
            }

        }
        #endregion

        #region DeleteGallery
        public IActionResult DeleteProductGallery(int ProductId)
        {
            
            var result = productGalleryService.DeleteGallery(ProductId);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    break;
            }
            return View();
        }
        #endregion 
    }
}
