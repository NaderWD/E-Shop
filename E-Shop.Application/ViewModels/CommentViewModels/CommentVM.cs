using E_Shop.Domain.Models.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.CommentViewModels
{
    #region User
    public class CommentVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }           
        public bool IsApproved { get; set; }                   
        public string? ProductName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public List<ReplyVM>? Replies { get; set; }
    }

    public class ProductCommentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CommentVM>? Comments { get; set; }
    }

    public class CreateCommentVM
    {
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AuthorName { get; set; }

        public int ProductId { get; set; }
    }
    #endregion

    #region Admin
    public class ReplyVM
    {
        public int Id { get; set; }
        public string Text { get; set; }                     
        public string AdminName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class CreateReplyVM
    {
        public string Text { get; set; }
        public int CommentId { get; set; }
    }
    #endregion
}
