using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.Color
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
}
