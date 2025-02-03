using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Shop.Domain.Models
{
    public class User2 : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? RepeatPassword { get; set; }

        [Required]
        [MaxLength(500)]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public Address? Address { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}
