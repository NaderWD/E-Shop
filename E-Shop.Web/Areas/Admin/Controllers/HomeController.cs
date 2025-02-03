using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : BaseAdminController
    {
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
