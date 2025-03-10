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
            return RedirectToAction("ProductDetail", "Product", new { productId = commentVM.ProductId, area = "" });
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
            var likeCount = await _commentService.LikeComment(commentId, userId);
            return RedirectToAction(nameof(ProductComments));

        }

        [HttpPost]
        public async Task<IActionResult> DislikeComment(int commentId)
        {
            var dislikeCount = await _commentService.DisLikeComment(commentId);
            return RedirectToAction(nameof(ProductComments));
        }
        #endregion
    }
}
