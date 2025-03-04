using E_Shop.Application.ViewModels.CommentViewModels;
using E_Shop.Domain.Contracts.CommentCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Models.CommentModels;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.UserModels;
using static E_Shop.Domain.Enum.CommentEnums;

namespace E_Shop.Application.Services.CommentService
{
    public class CommentService(ICommentRepository _repository, IUserRepository _userRepository) : ICommentService
    {
        public async Task CreateComment(CreateCommentVM commentVM)
        {
            Comment comment = new()
            {
                AuthorName = commentVM.AuthorName,
                Text = commentVM.Text,
                Status = CommentStatus.InProgress,
                ProductId = commentVM.ProductId,
                IsApproved = false,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LikeCounts = 0,
                DisLikeCounts = 0,
                Evaluations = []
            };
            foreach (var eval in commentVM.PositiveEvaluations.Where(e => !string.IsNullOrWhiteSpace(e.Text)))
            {
                comment.Evaluations.Add(new Evaluation { Text = eval.Text, IsPositive = true });
            }

            // Add negative evaluations
            foreach (var eval in commentVM.NegativeEvaluations)
            {
                comment.Evaluations.Add(new Evaluation { Text = eval.Text, IsPositive = false });
            }
            await _repository.AddCommentAsync(comment);
            await Save();
        }

        public async Task CreateReply(CreateReplyVM replyVM, bool isAdmin = false)
        {
            Reply reply = new()
            {
                AuthorName = replyVM.AuthorName,
                Text = replyVM.Text,
                CommentId = replyVM.CommentId,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                IsAdminReply = isAdmin,
            };
            await _repository.AddReplyAsync(reply);
            await Save();
        }

        public async Task<int> LikeComment(int commentId, int userId)
        {
            var comment = await _repository.GetCommentByIdAsync(commentId);
            if (comment.Likes?.Any(u => u.UserId == userId) == true) return comment.LikeCounts;
            comment.LikeCounts++;
            comment.Likes ??= [];
            comment.Likes.Add(new Like { CommentId = commentId, UserId = userId });
            await _repository.UpdateCommentAsync(comment);
            await Save();
            return comment.LikeCounts;
        }

        public async Task<int> DisLikeComment(int commentId)
        {
            var comment = await _repository.GetCommentByIdAsync(commentId);
            comment.DisLikeCounts++;
            await Save();
            return comment.DisLikeCounts;
        }

        public async Task<CreateCommentVM> GetCreateCommentVM(int productId, int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return new CreateCommentVM
            {
                ProductId = productId,
                AuthorName = user?.FirstName,
                Text = "",
                PositiveEvaluations = [],
                NegativeEvaluations = []
            };
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
            => await _repository.GetCommentByIdAsync(commentId);

        public async Task<IEnumerable<CommentVM>> GetApprovedCommentListByProductId(int productId)
        {
            var comments = await _repository.GetApprovedCommentsByProductIdAsync(productId);
            return comments.Select(c => new CommentVM
            {
                Id = c.Id,
                AuthorName = c.AuthorName,
                ProductName = c.Product.Title,
                Text = c.Text,
                CreateDate = c.CreateDate,
                LastModifiedDate = c.LastModifiedDate,
                Replies = [.. c.Replies.Select(r => new ReplyVM
                {
                    Id = r.Id,
                    AuthorName = r.AuthorName,
                    Text = r.Text,
                    CreateDate = r.CreateDate,
                    LastModifiedDate = r.LastModifiedDate
                })],
            });
        }

        public async Task<IEnumerable<CommentVM>> GetUnApprovedCommentList()
        {
            var comments = await _repository.GetUnapprovedCommentsAsync();
            return comments.Select(c => new CommentVM
            {
                Id = c.Id,
                AuthorName = c.AuthorName,
                Text = c.Text,
                LikeCount = c.LikeCounts,
                CreateDate = c.CreateDate,
                ProductName = c.Product.Title
            });
        }

        public async Task ApproveComment(int commentId)
        {
            await _repository.ApproveCommentAsync(commentId);
            await Save();
        }

        public async Task<ProductCommentVM> GetProductById(int productId)
        {
            var product = await _repository.GetProductByIdAsync(productId);
            return new ProductCommentVM()
            {
                Id = product.Id,
                Name = product.Title,
                Description = product.Description,
                Comments = [.. product.Comments.Where(x => x.IsApproved).Select(c => new CommentVM
                {
                    Id = c.Id,
                    AuthorName = c.AuthorName,
                    Text = c.Text,
                    LikeCount = c.LikeCounts,
                    ProductName = c.Product.Title,
                    CreateDate = c.CreateDate,
                    LastModifiedDate = c.LastModifiedDate,
                    Replies = [.. c.Replies.Select(r => new ReplyVM
                    {
                        Id = r.Id,
                        AuthorName = r.AuthorName,
                        Text = r.Text,
                        CreateDate = r.CreateDate,
                        LastModifiedDate = r.LastModifiedDate
                    })]
                })]
            };
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _repository.GetCommentByIdAsync(commentId);
            comment.IsDelete = true;
            await _repository.UpdateCommentAsync(comment);
            await Save();
        }

        public async Task Save() => await _repository.Save();
    }
}
