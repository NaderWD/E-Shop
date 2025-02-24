namespace E_Shop.Domain.Models.SpecificationModels
{
    public class Specification : BaseModel
    {
        public string Name { get; set; }
        public int? ProductSpecificationId { get; set; }

        public ICollection<ProductSpecification>? ProductSpecification { get; set; }
    }
}
