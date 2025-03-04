using E_Shop.Application.ViewModels.CommentViewModels;

namespace E_Shop.Application.Services.CommentService
{
    public interface ICommentService
    {
        Task CreateComment(CreateCommentVM commentVM);
        Task CreateReply(CreateReplyVM replyVM, bool isAdmin = false);
        Task<int> LikeComment(int commentId);          
        Task<int> DisLikeComment(int commentId);
        Task<IEnumerable<CommentVM>> GetApprovedCommentListByProductId(int productId);
        Task<IEnumerable<CommentVM>> GetUnApprovedCommentList();
        Task ApproveComment(int commentId);
        Task<ProductCommentVM> GetProductById(int productId);
        Task DeleteComment(int commentId);
        Task Save();
    }
}
