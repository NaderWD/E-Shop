using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductsController(IProductsService productsService) : Controller
    {
        public IActionResult ProductIndex()
        {
            var content = productsService.GetAll();
            return View(content);
        }
    }
}
