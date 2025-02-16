using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductCategoriesController(IProductCategoriesService productCategoriesService) : Controller
    {
        [Route("ProductList")]
        public IActionResult Index()
        {
            var content = productCategoriesService.GetAll();
            return View(content);
        }
    }
}
