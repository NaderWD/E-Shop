using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ContactUsMessageController(IContactUsService contactUsService) : AdminBaseController
    {
        public IActionResult Index()
        {
            var content = contactUsService.GetAll();
            return View(content);
        }
    }
}
