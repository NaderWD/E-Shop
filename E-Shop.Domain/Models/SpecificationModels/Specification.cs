﻿using System.Numerics;

namespace E_Shop.Domain.Models.SpecificationModels
{
    public class Specification : BaseModel
    {                                              
        public string Name { get; set; }
        public int ProductSpecificationId { get; set; }
        public int CategorySpecificationId { get; set; }

        public ICollection<ProductSpecification>? ProductSpecifications { get; set; }
        public ICollection<CategorySpecification>? CategorySpecifications { get; set; }
    }
}
