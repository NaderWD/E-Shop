using E_Shop.Domain.Models.CommentModels;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Contracts.CommentCont
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);           
        Task AddReplyAsync(Reply reply);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<IEnumerable<Comment>> GetApprovedCommentsByProductIdAsync(int productId);
        Task<IEnumerable<Comment>> GetUnapprovedCommentsAsync();                               
        Task<IEnumerable<Reply>> GetRepliesByProductIdAsync(int productId);
        Task ApproveCommentAsync(int commentId);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteComment(int commentId);
        Task Save();
        Task<Product> GetProductByIdAsync(int productId);
    }
}
