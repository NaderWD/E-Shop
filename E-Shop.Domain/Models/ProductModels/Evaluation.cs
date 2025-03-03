using E_Shop.Domain.Models.CommentModels;

namespace E_Shop.Domain.Models.ProductModels
{
    public class Evaluation : BaseModel
    {
        public int CommentId { get; set; }      
        public Comment Comment { get; set; }    
        public string Text { get; set; }        
        public bool IsPositive { get; set; }     
    }
}
