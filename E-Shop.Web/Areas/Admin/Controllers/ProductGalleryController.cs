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
            TempData["ProductId"] = productId;
            ViewData["ProductId"] = TempData["ProductId"];
            TempData.Keep("ProductId");
            return View(content);
        }
        #region AddGallery

        public IActionResult AddProductGallery(int productId)
        {
            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata; 
            TempData.Keep("ProductId");
            return View();
        }

        [HttpPost]
        public IActionResult AddProductGallery(AddProductGalleryViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }
            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");
            var result = productGalleryService.CreateGallery(model);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductGalleryIndex", new { productId = tempdata });

                case true:
                    TempData[SuccessMessage] = ErrorMessages.GalleryAdded;
                    return RedirectToAction("ProductGalleryIndex", new { productId = tempdata });
            }

        }
        #endregion

        #region DeleteGallery
        public IActionResult DeleteProductGallery(int Id)
        {
            ViewData["ProductId"] = TempData["ProductId"];
            TempData.Keep("ProductId");

            var result = productGalleryService.DeleteGallery(Id);
            
            
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductGalleryIndex", new { productId = TempData["ProductId"] });

                case true:
                    TempData[SuccessMessage] = ErrorMessages.GalleryDeleted;
                    return RedirectToAction("ProductGalleryIndex", new { productId = TempData["ProductId"] });
            }
            
        }
        #endregion 
    }
}
