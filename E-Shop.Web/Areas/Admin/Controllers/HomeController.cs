using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminBaseController
    {
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }



    }
}
