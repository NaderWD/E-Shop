using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserTicketController : UserBaseController    
    {
        public IActionResult CreateTicketMessage()
        {
            return View();
        }
    }
}
