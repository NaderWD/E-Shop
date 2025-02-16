using AspNetCoreGeneratedDocument;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductCategoriesController(IProductCategoriesService productCategoriesService) : AdminBaseController 
    {
        public IActionResult Index()
        {
            var content = productCategoriesService.GetAll();

            return View(content);
        }

        #region Create Category
        public IActionResult CreateProductCategory()
        {
            var content = productCategoriesService.GetCreatModel();
            ViewBag.parentList = new SelectList(content.ParentList?? new List<SelectListitem>()  , "Id" , "Name");
            return View(content);
        }

        [HttpPost]
        public IActionResult CreateProductCategory(CreatProductCategoryViewModel model )
        {
            if (!ModelState.IsValid) { return View(model); }

            var result = productCategoriesService.CreateproductCategory(model);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.Categoryduplicated;
                    return RedirectToAction("Index");
                    
                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductCategoryAdded;
                    break;
            }
            return RedirectToAction("Index");

        }

        #endregion CreateCategory
    }
}
