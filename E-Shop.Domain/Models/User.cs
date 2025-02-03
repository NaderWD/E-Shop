using E_Shop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models
{
    public class User : BaseModel
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

        [Required]
        [MaxLength(500)]
        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set; }
    }
}
