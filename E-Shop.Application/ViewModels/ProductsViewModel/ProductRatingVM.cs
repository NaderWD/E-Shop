using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.ProductsViewModel
{
    public class CreateProductRatingVM
    {
        public int ProductId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RaterName { get; set; }
        [Display(Name = "امتیاز کلی")]
        [Range(1, 5, ErrorMessage = "امتیاز باید بین 1 تا 5 باشد")]
        public double OverallRating { get; set; }
        [Display(Name = "کیفیت ساخت")]
        [Range(1, 5)]
        public double BuildQuality { get; set; }
        [Display(Name = "ارزش خرید به نسبت قیمت")]
        [Range(1, 5)]
        public double ValueForMoney { get; set; }
        [Display(Name = "نوآوری")]
        [Range(1, 5)]
        public double Innovation { get; set; }
        [Display(Name = "امکانات و قابلیت ها")]
        [Range(1, 5)]
        public double Features { get; set; }
        [Display(Name = "سهولت استفاده")]
        [Range(1, 5)]
        public double EaseOfUse { get; set; }
        [Display(Name = "طراحی و ظاهر")]
        [Range(1, 5)]
        public double Design { get; set; }
    }

    public class ProductRatingSummaryVM
    {
        public double OverallRating { get; set; }
        public double BuildQuality { get; set; }
        public double ValueForMoney { get; set; }
        public double Innovation { get; set; }
        public double Features { get; set; }
        public double EaseOfUse { get; set; }
        public double Design { get; set; }
        public int RatingCount { get; set; }
    }
}
