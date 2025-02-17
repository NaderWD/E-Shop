using E_Shop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models.Products
{
    public class Products : BaseModel
    {
        public string Title { get; set; }
        public int Price { get; set; }

    }
}
