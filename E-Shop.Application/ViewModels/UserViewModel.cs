using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels
{
    public class UserViewModel 
    {
        
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "نام نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        [Required(ErrorMessage = "وارد کردن نام ضروری است.")]
        public string? FirstName { get; set; }

        [MaxLength(255, ErrorMessage = "نام خانوادگی نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        public string? LastName { get; set; }

        [MaxLength(255, ErrorMessage = "رمز عبور نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا رمز جدید را وارد کنید.")]
        public string? Password { get; set; }

        [MaxLength(500, ErrorMessage = "آدرس ایمیل نباید بیشتر از ۵۰۰ کاراکتر باشد.")]
        [Required(ErrorMessage = "وارد کردن آدرس ایمیل ضروری است.")]
        public string? EmailAddress { get; set; }

        [MaxLength(500, ErrorMessage = "شماره موبایل نباید بیشتر از ۵۰۰ کاراکتر باشد.")]
        public string? Mobile { get; set; }

        public bool? IsAdmin { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
    }
    
}
