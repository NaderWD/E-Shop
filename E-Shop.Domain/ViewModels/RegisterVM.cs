using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.ViewModels
{
    public class RegisterVM : BaseModel
    {
        [MaxLength(255)]
        public string UserName { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Repassword { get; set; }

        [MaxLength(500)]
        public string? EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }
    }
}
