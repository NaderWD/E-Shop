using E_Shop.Domain.Models.UserModels;

namespace E_Shop.Domain.Models.CommentModels
{
    public class Reply : BaseModel
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }                              
        public int UserId { get; set; }
        public User User { get; set; }       
        public int CommentId { get; set; }  
        public Comment Comment { get; set; }            
        public bool IsAdminReply { get; set; }
    }
}
