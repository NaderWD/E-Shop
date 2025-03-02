using E_Shop.Domain.Models.ProductModels;
using static E_Shop.Domain.Enum.CommentEnums;

namespace E_Shop.Domain.Models.CommentModels
{
    public class Comment : BaseModel
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public bool IsApproved { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public IQueryable<Reply> Replies { get; set; }
        public CommentStatus Status { get; set; }
    }
}
