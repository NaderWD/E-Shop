using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductController(IProductsService productsService) : SiteBaseController
    {
        public IActionResult ProductsArchive(int categoryId)
        {
            var content = productsService.GetByCategoryId(categoryId);
            return View(content);
        }
    }
}
