using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Discount : BaseModel
    {
        

        [Required]
        [Range(0, 100)]
        public decimal Percentage { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        
        public ICollection<Product> Products { get; set; }
    }
}
