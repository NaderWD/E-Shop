using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Product : BaseModel
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

        [Display(Name = "تاریخ انقضا")]
        [Required]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "دسته ی محصولات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Category? Category { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را قرار دهید")]
        [DataType((DataType.ImageUrl))]
        public string? Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public decimal Price { get; set; }

        [Display(Name = "تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public Discount? Discount { get; set; }

        [Display(Name = "برند")]
        public string? Brand { get; set; }

        [Display(Name = "رنگ")]
        public string? Color { get; set; }
    }
}
