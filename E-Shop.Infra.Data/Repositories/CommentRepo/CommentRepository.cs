using E_Shop.Domain.Contracts.CommentCont;
using E_Shop.Domain.Models.CommentModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.CommentRepo
{
    public class CommentRepository(ShopDbContext _context) : ICommentRepository
    {
        public async Task CreateComment(Comment comment)
            => await _context.Comments.AddAsync(comment);

        public async Task<Comment> GetCommentById(int commentId)
            => await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId && !x.IsDelete);

        public async Task<IEnumerable<Comment>> GetCommentListByProductId(int productId)
            => await _context.Comments.Include(x => x.Product).Where(x => x.ProductId == productId).ToListAsync();

        public async Task UpdateComment(Comment comment)
            => _context.Comments.Update(comment);

        public async Task DeleteComment(int commentId)
            => _context.Comments.Remove(await GetCommentById(commentId));

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
