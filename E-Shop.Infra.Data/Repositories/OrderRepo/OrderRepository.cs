using E_Shop.Domain.Contracts.OrderCont;
using E_Shop.Domain.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.OrderRepo
{
    public class OrderRepository(ShopDbContext _dbContext) : IOrderRepository
    {
        #region CreateOrder
        public bool CreateOrder(Order modelOrder)
        {
            _dbContext.Orders.Add(modelOrder);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CreateOrderDetails(OrderDetails modeldetails)
        {
            _dbContext.OrderDetails.Add(modeldetails);
            _dbContext.SaveChanges();
            return true;
        }
        #endregion

        #region UpdateOrder
        public bool UpdateOrder(Order modelOrder)
        {
            _dbContext.Orders.Update(modelOrder);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateOrderDetails(OrderDetails model)
        {
            _dbContext.OrderDetails.Update(model);
            _dbContext.SaveChanges();
            return true;
        }
        #endregion


        public Order GetOrderByUserId(int userId)
        {
            var order = _dbContext.Orders.Include(o => o.OrderDetails).Where(o => o.UserId == userId && o.IsFinally == false && o.IsDelete == false);
            if (order.Any())
            {
                return order.First();
            }
            else
            {
                return null;
            }
        }
        public List<OrderDetails> GetByOrderId(int orderId)
        {
            return _dbContext.OrderDetails.Where(d => d.OrderId == orderId && d.IsDelete == false).ToList();
        }
        public OrderDetails GetById(int OrderId, int productId)
        {
            var orderdetail = _dbContext.OrderDetails.Where(d => d.OrderId == OrderId && d.ProductId == productId);
            if (orderdetail.Any())
            {
                return orderdetail.First();
            }
            else
            {
                return null;
            }
        }

        public bool UpdateOrder(OrderDetails modeldetails, Order modelOrder)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.Find(orderId);
        }

        
    }
}
