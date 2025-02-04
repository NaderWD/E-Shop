using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class LoginVM
    {
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        public enum LoginResult
        {
            Success,
            Error,
            UserNotFound
        }
    }
}
