using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        [Route("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
