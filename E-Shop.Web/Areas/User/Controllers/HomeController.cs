﻿using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        [Route("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
