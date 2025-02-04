using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class ForgetPassword
    {
        public string EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }
    }
}
