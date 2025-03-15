using E_Shop.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.OrderCont
{
    public interface IOrderRepository
    {
        Order GetOrderByUserId(int userId);
        Order GetOrderById(int orderId);
        List<OrderDetails> GetByOrderId(int orderId);
        
        bool UpdateOrder(OrderDetails modeldetails , Order modelOrder);
        bool CreateOrder(Order modelOrder);
        bool UpdateOrder(Order modelOrder);
        bool UpdateOrderDetails(OrderDetails model);
        bool CreateOrderDetails(OrderDetails modeldetails);
        OrderDetails GetById(int OrderId, int productId);
    }
}
