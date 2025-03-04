using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models.DiscountsModels
{
    public class Discount : BaseModel
    {
        
        public string? Code { get; set; }
        public int? DiscountPercentage { get; set; }
        public int? DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        

        
        public ICollection<DiscountProductMapping> DiscountProductMappings { get; set; }
    }
}
