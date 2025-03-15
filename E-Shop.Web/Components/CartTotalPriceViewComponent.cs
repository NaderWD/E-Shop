using E_Shop.Application.Services.Order;
using E_Shop.Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class CartTotalPriceViewComponent(IOrderService _orderService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int userid = User.GetUserId();
            var content = _orderService.GetOrder(userid)?.TotalPrice ?? 0;
            return View("GetCartTotalPrice", content);
        }
    }
}
