using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class ProductGalleriesViewComponent(IProductGalleryService productGalleryService) : ViewComponent
    {
        public IViewComponentResult Invoke(int productId)
        {
            var content = productGalleryService.GetGalleryByProductId(productId);
            return View("GetProductGalleries", content);
        }
    }
}
