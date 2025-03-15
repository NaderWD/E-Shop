using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.Order
{
    public class OrderDetails : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int Price { get; set; }
        public float? OffPrice { get; set; }
        public int Count { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }

}
