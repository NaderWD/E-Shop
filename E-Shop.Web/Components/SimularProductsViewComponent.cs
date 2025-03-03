using E_Shop.Application.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class SimularProductsViewComponent(IProductsService productsService) : ViewComponent
    {
        public IViewComponentResult Invoke(int categoryId)
        {
           var content = productsService.GetByCategoryId(categoryId);
            return View("GetSimularProducts" , content);
        }
    }
}
