using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Category : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(2000)]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [DataType((DataType.ImageUrl))]
        public string? Image { get; set; }
    }
}
