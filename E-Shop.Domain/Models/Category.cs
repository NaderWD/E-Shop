using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Category : BaseModel
    {
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را قرار دهید")]
        [DataType((DataType.ImageUrl))]
        public string? Image { get; set; }
    }
}
