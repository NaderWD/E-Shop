using E_Shop.Domain.Contracts.CommentCont;
using E_Shop.Domain.Models.CommentModels;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.CommentRepo
{
    public class CommentRepository(ShopDbContext _context) : ICommentRepository
    {
        public async Task AddCommentAsync(Comment comment)
            => await _context.Comments.AddAsync(comment);

        public async Task AddReplyAsync(Reply reply)
            => await _context.Replies.AddAsync(reply);

        public async Task<Comment> GetCommentByIdAsync(int commentId)
            => await _context.Comments.FindAsync(commentId);

        public async Task<IEnumerable<Comment>> GetApprovedCommentsByProductIdAsync(int productId)
            => _context.Comments.Include(x => x.Replies).ThenInclude(x => x.User).Where(x => !x.IsDelete && x.IsApproved);

        public async Task<IEnumerable<Comment>> GetUnapprovedCommentsAsync()
            => _context.Comments.Include(x => x.Product).ThenInclude(x => x.Comments).Where(x => !x.IsDelete && !x.IsApproved);

        public async Task<IEnumerable<Reply>> GetRepliesByProductIdAsync(int productId)
            => _context.Replies.Include(x => x.Comment).Where(x => x.Comment.ProductId == productId);

        public async Task ApproveCommentAsync(int commentId)
        {
            var comment = await GetCommentByIdAsync(commentId);
            if (comment != null) comment.IsApproved = true;
        }

        public async Task UpdateCommentAsync(Comment comment)
            => _context.Comments.Update(comment);

        public async Task DeleteComment(int commentId)
            => _context.Comments.Remove(await GetCommentByIdAsync(commentId));

        public async Task Save()
            => await _context.SaveChangesAsync();

        public async Task<Product> GetProductByIdAsync(int productId)
            => await _context.Products.FirstOrDefaultAsync(x => x.Id == productId && !x.IsDelete);
    }
}
