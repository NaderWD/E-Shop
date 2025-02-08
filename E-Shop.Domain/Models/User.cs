using E_Shop.Domain.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {
        [MaxLength(255)]
        public string? FirstName { get; set; }

        [MaxLength(255)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [MaxLength(255)]
        public string? Mobile { get; set; }

        [MaxLength(255)]
        public string? ActivationCode { get; set; }

        public string? UserName { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsActive { get; set; }
    }

}
