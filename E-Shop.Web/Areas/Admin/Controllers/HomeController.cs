using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminBaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        
        
    }
}
