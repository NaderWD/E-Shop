using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {
        [MaxLength(255, ErrorMessage = "نام نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        [Required(ErrorMessage = "وارد کردن نام ضروری است.")]
        public string? FirstName { get; set; }

        [MaxLength(255, ErrorMessage = "نام خانوادگی نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "وارد کردن نام کاربری ضروری است.")]
        [MinLength(8, ErrorMessage = "نام کاربری باید حداقل ۸ کاراکتر باشد.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "نام کاربری باید شامل حداقل یک حرف بزرگ، یک حرف کوچک و یک عدد باشد.")]
        public string? UserName { get; set; }

        [MaxLength(255, ErrorMessage = "رمز عبور نباید بیشتر از ۲۵۵ کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا رمز جدید را وارد کنید.")]
        public string Password { get; set; }

        [MaxLength(500, ErrorMessage = "آدرس ایمیل نباید بیشتر از ۵۰۰ کاراکتر باشد.")]
        [Required(ErrorMessage = "وارد کردن آدرس ایمیل ضروری است.")]
        public string EmailAddress { get; set; }

        [MaxLength(500, ErrorMessage = "شماره موبایل نباید بیشتر از ۵۰۰ کاراکتر باشد.")]
        public string? Mobile { get; set; }

        [MaxLength(255)]
        public string? ActivationCode { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive{get; set;}
    }
}
