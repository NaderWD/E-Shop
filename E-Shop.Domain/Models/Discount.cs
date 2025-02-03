using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Discount : BaseModel
    {
        [Display(Name = "میزان درصد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(0, 100)]
        public decimal? Percentage { get; set; }

        [Display(Name = "تاریخ شروع تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ اتمام تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime EndDate { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Description { get; set; }

        [Display(Name = "قیمت بعد از تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public decimal? PriceAfterDiscount { get; set; }
    }
}
