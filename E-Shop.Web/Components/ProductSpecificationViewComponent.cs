using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class ProductSpecificationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("GetProductSpecification");
        }
    }
}
