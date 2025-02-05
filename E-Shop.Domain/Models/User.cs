using E_Shop.Domain.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(500)]
        public string EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }

        public Guid? ActivationCode { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
    }
}
