using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.ColorViewModels
{
    public class ColorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن کد الزامی است")]
        [StringLength(7, ErrorMessage = "کد باید دقیقاً ۷ کاراکتر باشد", MinimumLength = 7)]
        [RegularExpression("#[0-9A-Fa-f]{6}", ErrorMessage = "کد باید به فرم #RRGGBB باشد")]
        public string Code { get; set; }


    }
    public class CreateColorViewModel
    {

        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن کد الزامی است")]
        [StringLength(7, ErrorMessage = "کد باید دقیقاً ۷ کاراکتر باشد", MinimumLength = 7)]
        [RegularExpression("#[0-9A-Fa-f]{6}", ErrorMessage = "کد باید به فرم #RRGGBB باشد")]
        public string Code { get; set; }


    }
    public class ProductColorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن کد الزامی است")]
        [StringLength(7, ErrorMessage = "کد باید دقیقاً ۷ کاراکتر باشد", MinimumLength = 7)]
        [RegularExpression("#[0-9A-Fa-f]{6}", ErrorMessage = "کد باید به فرم #RRGGBB باشد")]
        public string Code { get; set; }

        public bool IsDefault { get; set; }

        public int Price { get; set; }
    }

    public class AddColorToProductViewModel
    {
        
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد")]
        public string? Name { get; set; }

        
        [StringLength(7, ErrorMessage = "کد باید دقیقاً ۷ کاراکتر باشد", MinimumLength = 7)]
        [RegularExpression("#[0-9A-Fa-f]{6}", ErrorMessage = "کد باید به فرم #RRGGBB باشد")]
        public string? Code { get; set; }

        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "وارد کردن کد الزامی است")]
        public int ColorId { get; set; }
        
        public bool IsDefault { get; set; }
        
        [Required(ErrorMessage = "وارد کردن مبلغ الزامی است")]
        public int Price { get; set; }

    }
    public class UpdateColorForProduct
    {
        public int Id { get; set; }

        public int ProsuctId { get; set; }

        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [StringLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن کد الزامی است")]
        [StringLength(7, ErrorMessage = "کد باید دقیقاً ۷ کاراکتر باشد", MinimumLength = 7)]
        [RegularExpression("#[0-9A-Fa-f]{6}", ErrorMessage = "کد باید به فرم #RRGGBB باشد")]
        public string Code { get; set; }

        public bool IsDefault { get; set; }

        public int Price { get; set; }

        List<ColorViewModel> colors { get; set; }
    }

}
