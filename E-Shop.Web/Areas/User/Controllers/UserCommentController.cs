using E_Shop.Application.Services.CommentService;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class UserCommentController(ICommentService _commentService) : UserBaseController
    {
        #region Product Approved Comments
        [HttpGet]
        public async Task<IActionResult> ProductComments(int productId)
        {
            return View(await _commentService.GetApprovedCommentListByProductId(productId));
        }
        #endregion

        #region Create Comment 
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentVM commentVM)
        {
            if (!ModelState.IsValid) return View(commentVM);
            await _commentService.CreateComment(commentVM);
            return RedirectToAction("ProductDetails", "Products");
        }
        #endregion

        #region Create Reply
        [HttpGet]
        public async Task<IActionResult> CreateReply(int commentId)
        {
            return View(new CreateReplyVM { CommentId = commentId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply(CreateReplyVM replyVM)
        {
            if (!ModelState.IsValid) return View(replyVM);
            await _commentService.CreateReply(replyVM, false);
            return View();
        }
        #endregion

        #region Like Comment
        [HttpPost]
        public async Task<IActionResult> LikeComment(int commentId)
        {
            try
            {
                var likeCount = await _commentService.LikeComment(commentId);
                return Json(new { success = true, likeCount });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DislikeComment(int commentId)
        {
            try
            {
                var dislikeCount = await _commentService.DisLikeComment(commentId);
                return Json(new { success = true, dislikeCount });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        #endregion

        #region Delete Comment
        [HttpGet]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _commentService.DeleteComment(commentId);
            return RedirectToAction();
        }
        #endregion
    }
}
