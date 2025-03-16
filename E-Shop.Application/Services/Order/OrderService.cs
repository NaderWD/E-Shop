using E_Shop.Application.Services.DiscountServices;
using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.OrdersViewModel;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.OrderCont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shop.Domain.Models.Order;
using E_Shop.Domain.Models.DiscountsModels;
using E_Shop.Domain.Models.ProductModels;
using System.Drawing;

namespace E_Shop.Application.Services.Order
{
    public class OrderService(IOrderRepository _orderRepository, IProductsService _productService, IProductDiscountService _productDiscountService) : IOrderService
    {
        public bool AddProduct(CreateOrderViewModel model)
        {
            var order = _orderRepository.GetOrderByUserId(model.UserId);
            var orderdetail = _orderRepository.GetById(order.Id, model.ProductId);

            var product = _productService.GetById(model.ProductId);
            if (orderdetail == null)
            {
                #region OffPrice
                var price = product.Price + product.Colors.Where(c => c.Id == model.ColorId).FirstOrDefault().ColorPrice;

                var discount = _productDiscountService.GetDiscountForProduct(model.ProductId);

                var offprice = discount.Any(d => d.IsAppliedToAll) ?
                    _productDiscountService.ApplypublicDiscountByVM(discount.OrderBy(d => d.CreateDate).Last(d => d.IsAppliedToAll), price.Value)

                        : _productDiscountService.ApplyDiscount(discount.Select(d => new DiscountsViewModel
                        {
                            Code = d.Code,
                            DiscountAmount = d.DiscountAmount,
                            DiscountPercentage = d.DiscountPercentage,
                            EndDate = d.EndDate,
                            StartDate = d.StartDate,
                            IsActive = d.IsActive,
                            IsAppliedToAll = d.IsAppliedToAll,
                            ProductId = model.ProductId,
                        }).ToList(), price.Value);
                #endregion

                OrderDetails modelDetails = new OrderDetails()
                {
                    OrderId = order.Id,
                    CreateDate = DateTime.Now,
                    Price = product.Price,
                    ProductId = model.ProductId,
                    Count = model.count,
                    OffPrice = offprice,

                    ColorId = model.ColorId,

                };
                if (model.ColorId != 0)
                {
                    modelDetails.ColorId = model.ColorId;
                }
                else
                {
                    modelDetails.ColorId = product.Colors.Where(c => c.IsDefault).FirstOrDefault().Id;
                }

                _orderRepository.CreateOrderDetails(modelDetails);
                return true;
            }
            else
            {
                orderdetail.Count = orderdetail.Count + 1;
                _orderRepository.UpdateOrderDetails(orderdetail);
                return true;
            }


        }

        public bool CreateOrder(CreateOrderViewModel order)
        {
            var product = _productService.GetById(order.ProductId);
            if (product.Inventory > 0)
            {
                #region OffPrice
                var price = order.ColorId == 0 ? product.Price + product.Colors.Where(c => c.IsDefault == true).FirstOrDefault().ColorPrice
                    : product.Price + product.Colors.Where(c => c.Id == order.ColorId).FirstOrDefault().ColorPrice;

                var discount = _productDiscountService.GetDiscountForProduct(order.ProductId);

                var offprice = discount.Any(d => d.IsAppliedToAll) ?
                    _productDiscountService.ApplypublicDiscountByVM(discount.OrderBy(d => d.CreateDate).Last(d => d.IsAppliedToAll), price.Value)

                        : _productDiscountService.ApplyDiscount(discount.Select(d => new DiscountsViewModel
                        {
                            Code = d.Code,
                            DiscountAmount = d.DiscountAmount,
                            DiscountPercentage = d.DiscountPercentage,
                            EndDate = d.EndDate,
                            StartDate = d.StartDate,
                            IsActive = d.IsActive,
                            IsAppliedToAll = d.IsAppliedToAll,
                            ProductId = order.ProductId,
                        }).ToList(), price.Value);
                #endregion

                E_Shop.Domain.Models.Order.Order modelOrder = new Domain.Models.Order.Order()
                {
                    UserId = order.UserId,
                    CreateDate = DateTime.Now,
                    TotalPrice = offprice
                };
                _orderRepository.CreateOrder(modelOrder);

                OrderDetails modelDetails = new OrderDetails()
                {
                    OrderId = modelOrder.Id,
                    CreateDate = DateTime.Now,
                    Price = price.Value,
                    ProductId = order.ProductId,
                    Count = 1,
                    OffPrice = offprice,


                };
                if (order.ColorId != 0)
                {
                    modelDetails.ColorId = order.ColorId;
                }
                else
                {
                    modelDetails.ColorId = product.Colors.Where(c => c.IsDefault).FirstOrDefault().Id;
                }
                _orderRepository.CreateOrderDetails(modelDetails);
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public OrderViewModel GetOrder(int userId)
        {
            var Order = _orderRepository.GetOrderByUserId(userId);
            if (Order != null)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    UserId = Order.UserId,
                    OrderId = Order.Id,
                };
                model.orderProducts = new List<OrderProductViewModel>();

                foreach (var item in Order.OrderDetails)
                {

                    var product = _productService.GetById(item.ProductId);
                    var discount = _productDiscountService.GetDiscountForProduct(item.ProductId);
                    var colorId = 0;
                    if (item.ColorId != 0)
                    {
                        colorId = item.ColorId;
                    }
                    else
                    {
                        colorId = product.Colors.Where(c => c.IsDefault).FirstOrDefault().Id;
                    }

                    var price = item.ColorId == 0 ? product.Price + product.Colors.Where(c => c.IsDefault == true).FirstOrDefault().ColorPrice
                    : product.Price + product.Colors.Where(c => c.Id == item.ColorId).FirstOrDefault().ColorPrice;

                    model.orderProducts.Add(new OrderProductViewModel
                    {
                        ImageName = product.ImageName,
                        Price = price.Value,
                        Title = product.Title,

                        #region offprice

                        OffPrice = discount.Any(d => d.IsAppliedToAll) ?

                      _productDiscountService.ApplypublicDiscountByVM(discount.OrderBy(d => d.CreateDate).Last(d => d.IsAppliedToAll), price.Value)

                    : _productDiscountService.ApplyDiscount(discount.Select(d => new DiscountsViewModel
                    {
                        Code = d.Code,
                        DiscountAmount = d.DiscountAmount,
                        DiscountPercentage = d.DiscountPercentage,
                        EndDate = d.EndDate,
                        StartDate = d.StartDate,
                        IsActive = d.IsActive,
                        IsAppliedToAll = d.IsAppliedToAll,
                        ProductId = item.ProductId,
                    }).ToList(), price.Value),
                        #endregion

                        Count = item.Count,
                        ProductId = item.ProductId,
                        ColorId = colorId,
                    });


                }
                model.TotalPrice = (int)Order.OrderDetails.Sum(d => d.OffPrice);

                return model;
            }
            else
            {
                OrderViewModel model = new OrderViewModel();
                model.orderProducts = new List<OrderProductViewModel>();
                return model;
            }

        }

        public bool RemoveProduct(CreateOrderViewModel model)
        {
            var order = _orderRepository.GetOrderByUserId(model.UserId);
            var orderdetail = _orderRepository.GetById(order.Id, model.ProductId);

            orderdetail.Count = orderdetail.Count - 1;
            if (orderdetail.Count == 0)
            {
                
            }
            _orderRepository.UpdateOrderDetails(orderdetail);
            return true;
        }
    }
}
