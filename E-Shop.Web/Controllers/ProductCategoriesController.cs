using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductCategoriesController(IProductCategoriesService productCategoriesService) : Controller
    {
        public IActionResult Index()
        {
            var model = productCategoriesService.GetAll();
            return PartialView("_NavProductCategories", model);
        }

    }
}
