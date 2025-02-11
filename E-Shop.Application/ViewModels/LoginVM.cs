using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "ایمیل صحیح وارد کنید")]
        public string EmailAddress { get; set; }
    }
}
