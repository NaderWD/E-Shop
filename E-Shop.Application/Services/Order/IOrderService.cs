using E_Shop.Application.ViewModels.OrdersViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Order
{
    public interface IOrderService
    {
        bool AddProduct(CreateOrderViewModel model);
        bool RemoveProduct(CreateOrderViewModel model);
        bool CreateOrder(CreateOrderViewModel order);
        bool DeleteOrder();
        OrderViewModel GetOrder(int userId);
    }
}
