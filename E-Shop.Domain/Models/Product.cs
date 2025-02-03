using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Shop.Domain.Models
{
    public class Product : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(2000)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public Category? Category { get; set; }

        [DataType((DataType.ImageUrl))]
        public string? Image { get; set; }

        public string? Brand { get; set; }

        public string? Color { get; set; }
    }
}
