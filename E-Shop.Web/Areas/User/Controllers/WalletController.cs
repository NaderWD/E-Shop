using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class WalletController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }
        

    }
}
