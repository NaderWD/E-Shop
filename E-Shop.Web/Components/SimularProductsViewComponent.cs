using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class SimularProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("GetSimularProducts");
        }
    }
}
