using E_Shop.Domain.Models.CommentModels;

namespace E_Shop.Domain.Contracts.CommentCont
{
    public interface ICommentRepository
    {
        Task CreateComment(Comment comment);
        Task<Comment> GetCommentById(int commentId);
        Task<IEnumerable<Comment>> GetCommentListByProductId(int productId);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
        Task Save();
    }
}
