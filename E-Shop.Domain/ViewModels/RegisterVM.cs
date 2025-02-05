using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        [Compare("Password")]
        public string Repassword { get; set; }

        [MaxLength(500)]
        public string EmailAddress { get; set; }

        public string? ActivationCode { get; set; }

        public enum RegisterResult
        {
            Success,
            Error
        }
    }
}