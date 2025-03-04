using E_Shop.Application.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    // CommentsViewComponent.cs
    public class ProductCommentsViewComponent(ICommentService _commentService) : ViewComponent
    {                                                                               
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var comments = await _commentService.GetApprovedCommentListByProductId(productId);
            return View("ProductComments", comments);
        }
    }
}
