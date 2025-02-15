using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.Repositories.Interfaces;
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
        
        public IActionResult CreatProductCategory()
        {
            var model = productCategoriesService.GetAll().Where(c => c.ParentId == null);
            return View(model);
        }

    }
}
