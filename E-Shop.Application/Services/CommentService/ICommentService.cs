using E_Shop.Application.ViewModels.CommentViewModels;

namespace E_Shop.Application.Services.CommentService
{
    public interface ICommentService
    {
        Task CreateComment(CreateCommentVM commentVM, int userId);
        Task CreateReply(CreateReplyVM replyVM, int userId);
        Task<IQueryable<CommentVM>> GetApprovedCommentListByProductId(int productId);
        Task<IQueryable<CommentVM>> GetUnApprovedCommentList(int productId);
        Task ApproveComment(int commentId);
        Task<ProductCommentVM> GetProductById(int productId);
    }
}
