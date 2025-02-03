using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class ForgetPassword
    {
        [MaxLength(255)]
        public string UserName { get; set; }

        public string? EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }
    }
}
