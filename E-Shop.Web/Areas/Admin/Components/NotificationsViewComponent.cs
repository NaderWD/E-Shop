using E_Shop.Application.Services.ContactUsServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Components
{
    public class NotificationsViewComponent(IContactUsService contactUsService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var content = contactUsService.GetAllUnRead();
            return View("GetNotifications", content);
        }
    }
}
