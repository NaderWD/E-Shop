using System.ComponentModel.DataAnnotations;
using static E_Shop.Domain.Enum.UserEnums;

namespace E_Shop.Domain.Models.UserModels
{
    public class User : BaseModel
    {
        [Display(Name = "")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string? FirstName { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string? LastName { get; set; }

        [Display(Name = "نام خانوادکی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string? Password { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string? EmailAddress { get; set; }

        [Display(Name = "موبایل")]
        public string? Mobile { get; set; }

        public string? Image { get; set; }

        public string? Avatar { get; set; }

        public AvatarStatus? AvatarStatus { get; set; }

        [MaxLength(255)]
        public string? ActivationCode { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
    }
}
