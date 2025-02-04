using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Controllers
{
    public abstract class SiteBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorMessage = "ErrorMessage";
    }
}
