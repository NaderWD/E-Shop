using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class Products : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
