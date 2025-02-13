using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.AccountViewModels
{
    public class ResetPasswordVM
    {
        [Display(Name = "کد دریافت شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ActivationCode { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "ایمیل صحیح وارد کنید")]
        public string? EmailAddress { get; set; }
    }
}
