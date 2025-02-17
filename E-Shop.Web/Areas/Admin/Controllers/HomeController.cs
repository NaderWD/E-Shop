using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{

    public class HomeController(IUserService _service) : AdminBaseController
    {
        [Route("Admin")]
        public IActionResult Index(int userId)
        {

            return View();
        }



    }
}
