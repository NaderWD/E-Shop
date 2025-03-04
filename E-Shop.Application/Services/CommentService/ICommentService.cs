using E_Shop.Application.ViewModels.CommentViewModels;
using E_Shop.Domain.Models.CommentModels;

namespace E_Shop.Application.Services.CommentService
{
    public interface ICommentService
    {
        Task CreateComment(CreateCommentVM commentVM);
        Task CreateReply(CreateReplyVM replyVM, bool isAdmin = false);
        Task<int> LikeComment(int commentId, int userId);          
        Task<int> DisLikeComment(int commentId);
        Task<CreateCommentVM> GetCreateCommentVM(int productId, int userId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<CommentVM>> GetApprovedCommentListByProductId(int productId);
        Task<IEnumerable<CommentVM>> GetUnApprovedCommentList();
        Task ApproveComment(int commentId);
        Task<ProductCommentVM> GetProductById(int productId);
        Task DeleteComment(int commentId);
        Task Save();
    }
}
