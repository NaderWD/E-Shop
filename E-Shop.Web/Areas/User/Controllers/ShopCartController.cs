using E_Shop.Application.Services.Order;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.OrdersViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class ShopCartController(IOrderService _orderService) : UserBaseController
    {
        public IActionResult ShopCartIndex()
        {
            int userId = User.GetUserId();
            var content = _orderService.GetOrder(userId);
           
            return View(content ?? new OrderViewModel());
        }

        [HttpPost]
        public IActionResult AddProduct(CreateOrderViewModel model)
        {
            int userId = User.GetUserId();
            model.UserId = userId;
            var Order = _orderService.GetOrder(userId);
            if (Order.OrderId == 0)
            {
                var result = _orderService.CreateOrder(model);
            }
            else
            {
                var result = _orderService.AddProduct(model);
            }

            return RedirectToAction("ShopCartIndex");
        }

        [HttpPost]
        public IActionResult AddAnotherProduct(int productId ,int colorId)
        {
            int userId = User.GetUserId();

            CreateOrderViewModel model = new CreateOrderViewModel() 
            {
                ProductId = productId,
                UserId = userId,
                ColorId = colorId,
            };

            var result = _orderService.AddProduct(model);


            return RedirectToAction("ShopCartIndex");
        }

        [HttpPost]
        public IActionResult removeProduct(int productId, int colorId)
        {
            int userId = User.GetUserId();

            CreateOrderViewModel model = new CreateOrderViewModel()
            {
                ProductId = productId,
                UserId = userId,
                ColorId = colorId,
            };

            var result = _orderService.AddProduct(model);


            return RedirectToAction("ShopCartIndex");
        }

        
    }
}
