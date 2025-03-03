namespace E_Shop.Domain.Models.CommentModels
{
    public class Like : BaseModel
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public int UserId { get; set; }
    }
}
