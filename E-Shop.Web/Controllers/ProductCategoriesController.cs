using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public class ProductCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
