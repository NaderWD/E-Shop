using E_Shop.Domain.Models.SpecificationModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.ProductModels
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
