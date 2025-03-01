using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Models.CommentModels
{
    public class Comment : BaseModel
    {
        public string Name { get; set; }
        public string Title { get; set; }    
        public string Text { get; set; }
        public bool AdminApproved { get; set; }            
        public bool IsAdminReply { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
