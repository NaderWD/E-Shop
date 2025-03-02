using E_Shop.Application.ViewModels.CommentViewModels;

namespace E_Shop.Application.Services.CommentService
{
    public class CommentService : ICommentService
    {
        public Task CreateComment(CreateCommentVM commentVM, int userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateReply(CreateReplyVM replyVM, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentVM>> GetApprovedCommentListByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentVM>> GetUnApprovedCommentList(int productId)
        {
            throw new NotImplementedException();
        }

        public Task ApproveComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCommentVM> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
