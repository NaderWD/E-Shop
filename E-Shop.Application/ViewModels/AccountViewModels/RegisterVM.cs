using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.AccountViewModels
{
    public class RegisterVM
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(255)]
        public string? LastName { get; set; }

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
        public string EmailAddress { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set; }

        public string? ActivationCode { get; set; }
    }
}