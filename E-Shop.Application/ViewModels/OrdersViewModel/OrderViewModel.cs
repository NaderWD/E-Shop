using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.OrdersViewModel
{
    public class OrderViewModel
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderProductViewModel> orderProducts { get; set; }
    }
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int count { get; set; } = 1;
    }
    public class CreateOrderDetailViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int count { get; set; } = 1;
    }
    public class UpdateOrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }

    }
    public class OrderProductViewModel 
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int OffPrice { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int Count { get; set; }
    }

}
