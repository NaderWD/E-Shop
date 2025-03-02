using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserCommentController : Controller
    {
        #region Create
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(int id)
        {
            return View();
        }
        #endregion


    }
}
