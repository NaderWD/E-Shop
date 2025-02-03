using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Shop.Domain.Models
{
    public class Cart : BaseModel
    {
        [Required]
        public Order? Order { get; set; }

        [Required]
        public User2? User { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
    }
}
