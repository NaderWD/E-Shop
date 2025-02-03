using E_Shop.Domain.Models.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
    {
       
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? Password { get; set; }

        [MaxLength(500)]
        public string? EmailAddress { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
