using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ProductsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductController(IProductsService productsService) : SiteBaseController
    {
        public IActionResult ProductsArchive(FilterProductViewModel model)
        {
            var content = productsService.Filter(model);
            return View(content);
        }
    }
}
