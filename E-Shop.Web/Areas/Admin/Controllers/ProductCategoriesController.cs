using AspNetCoreGeneratedDocument;
using E_Shop.Application.Services.Implementations;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductCategoriesController(IProductCategoriesService productCategoriesService) : AdminBaseController
    {
        [Route("ProductList")]
        public IActionResult Index()
        {
            var content = productCategoriesService.GetAll();

            return View(content);
        }

        #region Create Category
        public IActionResult CreateProductCategory()
        {
            var content = productCategoriesService.GetCreatModel();
            ViewBag.parentList = new SelectList(content.ParentList ?? new List<SelectListitem>(), "Id", "Name");
            return View(content);
        }

        [HttpPost]
        public IActionResult CreateProductCategory(CreatProductCategoryViewModel model)
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

        #region Update Category
        public IActionResult UpdateProductCategory(int Id)
        {
            var content = productCategoriesService.GetUpdateModel(Id);
            ViewBag.parentList = new SelectList(content.ParentList ?? new List<SelectListitem>(), "Id", "Name");
            return View(content);
        }

        [HttpPost]
        public IActionResult UpdateProductCategory(CreatProductCategoryViewModel model)
        {
            var NameCheck = productCategoriesService.GetProductCategoryById(model.Id);
            if (!ModelState.IsValid) { return View(model); }

            else
            {
                if (NameCheck.Name == model.Name)
                {
                    var result = productCategoriesService.UpdateproductCategory(model, false);
                    switch (result)
                    {
                        case false:
                            TempData[ErrorMessage] = ErrorMessages.Categoryduplicated;
                            return RedirectToAction("Index");

                        case true:
                            TempData[SuccessMessage] = ErrorMessages.ProductCategoryAdded;
                            break;
                    }
                }
                else
                {
                    productCategoriesService.UpdateproductCategory(model, true);

                    TempData[SuccessMessage] = ErrorMessages.ProductCategoryAdded;
                }

                return RedirectToAction("Index");
            }


        }

        #endregion Update Category

        #region Delete Category
        public IActionResult DeleteProductCategory(int CategoryId)
        {
            var result = productCategoriesService.DeleteproductCategory(CategoryId);

            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ProductCategoryDeleted;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("Index");
            }
        }

        #endregion Delete Category
    }
}
