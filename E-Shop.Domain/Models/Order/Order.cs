using E_Shop.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models.Order
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public bool IsFinally { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }

}
