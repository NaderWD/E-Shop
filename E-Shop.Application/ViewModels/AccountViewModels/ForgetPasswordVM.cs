using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.AccountViewModels
{
    public class ForgetPasswordVM
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [EmailAddress(ErrorMessage = "ایمیل صحیح وارد کنید")]
        public string EmailAddress { get; set; }
    }
}
