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
        [HttpGet]
        public async Task<IActionResult> CreateComment(int productId)
        {
            var userId = User.GetUserId().ToString();
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int parsedUserId)) return RedirectToAction("Login", "Account");
            var model = await _commentService.GetCreateCommentVM(productId, parsedUserId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentVM commentVM)
        {
            if (!ModelState.IsValid) return View(commentVM);
            await _commentService.CreateComment(commentVM);
            return RedirectToAction("ProductDetails", "Products", new { productId = commentVM.ProductId });
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
            var userId = User.GetUserId();
            try
            {
                var likeCount = await _commentService.LikeComment(commentId, userId);
                return Json(new { success = true, likeCount });
            }
            catch
            {
                return Json(new { success = false, message = "لایک انجام نشد" });
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
            var comment = await _commentService.GetCommentByIdAsync(commentId);
            await _commentService.DeleteComment(commentId);
            return RedirectToAction(nameof(ProductComments), new { productId = comment.ProductId });
        }
        #endregion
    }
}
