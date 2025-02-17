using E_Shop.Application.Services.Implementations;
using E_Shop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class NavProductCategoriesViewComponent(IProductCategoriesService productCategoriesService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var content = productCategoriesService.GetAll();
            return View("GetNavProductCategories", content);
        }
    }
}
