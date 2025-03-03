using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductController(IProductsService productsService) : SiteBaseController
    {
        public IActionResult ProductsArchive(ProductArchiveViewModel model)
        {
            var content = productsService.ArchiveFilter(model);
            return View(content);
        }
        
        public IActionResult ProductDetail(int productId , int colorId)
        {
            var content = productsService.GetByIdForDetails(productId , colorId);
            return View(content);
        }
    }
}
