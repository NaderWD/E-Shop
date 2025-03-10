using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductController(IProductsService productsService) : SiteBaseController
    {
        public async Task<IActionResult> ProductsArchive(ProductArchiveViewModel model)
        {
            var content = await productsService.ArchiveFilter(model);
            return View(content);
        }
        
        public async  Task<IActionResult> ProductDetail(int productId , int colorId)
        {
            var content = await productsService.GetByIdForDetails(productId , colorId);
            return View(content);
        }
    }
}
