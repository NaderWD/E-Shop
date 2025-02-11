using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.ViewModels
{
    public class ContactUsMessageViewModel 
    {
        public int Id { get; set; }
        public  bool IsDeleted { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وارد کردن نام کامل الزامی است")]
        [Display(Name = "نام کامل")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر است")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "شماره موبایل نامعتبر است")]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "شماره موبایل باید با الگوی صحیح وارد شود (مثل 09123456789 یا +989123456789)")]
        [Display(Name = "شماره موبایل")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "وارد کردن پیام الزامی است")]
        [StringLength(500, ErrorMessage = "پیام نمی‌تواند بیش از ۵۰۰ کاراکتر باشد")]
        [Display(Name = "پیام")]
        public string Message { get; set; }

        public string? AdminAnswer { get; set; }
    }
}
