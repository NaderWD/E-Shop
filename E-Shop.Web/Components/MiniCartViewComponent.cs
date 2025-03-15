using E_Shop.Application.Services.Order;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.OrdersViewModel;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class MiniCartViewComponent(IOrderService _orderService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int userId = User.GetUserId();
            var content = _orderService.GetOrder(userId);
            return View("GetMiniCart",content ?? new OrderViewModel());
        }
    }
}
