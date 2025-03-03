using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class ProductCommentsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("GetProductComments");
        }
    }
}
