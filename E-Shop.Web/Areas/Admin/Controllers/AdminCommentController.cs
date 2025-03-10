﻿using E_Shop.Application.Services.CommentService;
using E_Shop.Application.ViewModels.CommentViewModels;
using Microsoft.AspNetCore.Mvc;



namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminCommentController(ICommentService _commentService) : AdminBaseController
    {
        #region All UnApproved Comment
        [HttpGet]
        public async Task<IActionResult> AllComments()
        {
            return View(await _commentService.GetUnApprovedCommentList());
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
            await _commentService.CreateReply(replyVM, true);
            return View();
        }
        #endregion

        #region Approve Comment
        [HttpPost]
        public async Task<IActionResult> ApproveComment(int commentId)
        {
            await _commentService.ApproveComment(commentId);
            return RedirectToAction(nameof(AllComments));
        }
        #endregion

        #region Delete Comment
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _commentService.GetCommentByIdAsync(commentId);
            await _commentService.DeleteComment(commentId);
            return RedirectToAction(nameof(AllComments));
        }
        #endregion
    }
}
