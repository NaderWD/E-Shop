using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class ForgetPasswordVM
    {
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string? ActivationCode { get; set; }
    }
}
