using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
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
