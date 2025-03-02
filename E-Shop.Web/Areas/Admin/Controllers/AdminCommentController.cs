using Microsoft.AspNetCore.Mvc;



namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminCommentController : Controller
    {
        public IActionResult AllComments(int productId)
        {
            return View();
        }
    }
}
