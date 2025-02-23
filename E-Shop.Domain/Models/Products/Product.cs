using E_Shop.Domain.Models.Color;
using E_Shop.Domain.Models.Common;
using E_Shop.Domain.Models.Specification;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.Products
{
    public class Product : BaseModel
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string? Review { get; set; }
        public string? ExpertReview { get; set; }
        public int Inventory { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategories Category { get; set; }
        public ICollection<ProductColorMapping> Color { get; set; }
        public ICollection<ProductSpecification>? ProductSpecification { get; set; }
    }
}
