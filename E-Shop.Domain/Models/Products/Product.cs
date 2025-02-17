using E_Shop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models.Products
{
    public class Product : BaseModel
    {
        [StringLength(100)]
        public string Title { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        public int CategoryId { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string? Review { get; set; }
        
        [DataType(DataType.MultilineText)]

        public string? ExpertReview { get; set; }

        [Range(0, int.MaxValue)]
        public int Inventory { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategories Category { get; set; }
    }
}
