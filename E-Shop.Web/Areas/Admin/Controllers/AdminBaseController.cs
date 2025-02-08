using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public abstract class AdminBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorMessage = "ErrorMessage";
    }
}
