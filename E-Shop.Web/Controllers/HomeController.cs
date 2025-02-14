using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.Models.Shared;
using E_Shop.Domain.ViewModels;
using E_Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Shop.Web.Controllers
{
    public class HomeController(IContactUsService contactUsService) : SiteBaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #region ContactUs
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [Route("ContactUs")]
        public IActionResult ContactUs(ContactUsMessageViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            else
            {
                var result =  contactUsService.SendMessage(model);
                switch (result)
                {
                    case true:
                        TempData[SuccessMessage] = ErrorMessages.MessageSent;
                        break;
                    case false:
                        TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                        return RedirectToAction("ContactUs");
                }
                return RedirectToAction("ContactUs");
            }
        }
        #endregion ContactUs

    }
}
