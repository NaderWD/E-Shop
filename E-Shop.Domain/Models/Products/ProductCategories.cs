using E_Shop.Domain.Models.Common;
using E_Shop.Domain.Models.Specification;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.Products
{
    public class ProductCategories : BaseModel
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public ProductCategories Parent { get; set; }
        public List<ProductCategories> SubCategories { get; set; }
        public ICollection<CategorySpecification>? CategorySpecification { get; set; }
    }
}
