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
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public List<LikeVM> Likes { get; set; }
        public List<EvaluationVM> Evaluations { get; set; } = [];
    }

    public class EvaluationVM
    {
        public string Text { get; set; }
        public bool IsPositive { get; set; }
    }

    public class LikeVM
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
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

        public List<EvaluationInputVM> PositiveEvaluations { get; set; } = [];

        public List<EvaluationInputVM> NegativeEvaluations { get; set; } = [];
    }

    public class EvaluationInputVM
    {
        public string Text { get; set; }
    }
    #endregion

    #region Admin
    public class ReplyVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public bool IsAdminReply { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }

    public class CreateReplyVM
    {
        public string AuthorName { get; set; }
        public string Text { get; set; }
        public int CommentId { get; set; }
    }
    #endregion
}
