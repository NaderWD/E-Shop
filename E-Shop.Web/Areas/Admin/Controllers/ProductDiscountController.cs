using E_Shop.Application.Services.DiscountServices;
using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ContactUsViewModels;
using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductDiscountController(IProductDiscountService productDiscountService) : AdminBaseController
    {
        public IActionResult DiscountIndex(int productId)
        {
            var content = productDiscountService.GetAllForProduct(productId);


            TempData["ProductId"] = productId;
            ViewData["ProductId"] = TempData["ProductId"];
            TempData.Keep("ProductId");


            return View(content);
        }
        #region CRUD

        public IActionResult AddDiscount(int productId)
        {
            var content = productDiscountService.GetAllSelect();
            ViewBag.Discounts = new SelectList(content ?? new List<DiscountsSelectViewModel>(), "Id", "DisplayText");

            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");
            return View();
        }
        [HttpPost]
        public IActionResult AddDiscount(AddMappingViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            var result = productDiscountService.AddMapping(model);

            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");

            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("DiscountIndex" , new {productId = TempData["ProductId"]});

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    return RedirectToAction("DiscountIndex" , new {productId = TempData["ProductId"]});
            }
        }


        public IActionResult UpdateDiscount(int mappingId)
        {
            var content = productDiscountService.GetByMappingID(mappingId);

            var select = productDiscountService.GetAllSelect();
            ViewBag.Discounts = new SelectList(select ?? new List<DiscountsSelectViewModel>(), "Id", "DisplayText");

            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");

            return View(content);
        }
        [HttpPost]
        public IActionResult UpdateDiscount(UpdateMappingViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var result = productDiscountService.UpdateMapping(model);

            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");

            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("DiscountIndex" , new {productId = TempData["ProductId"]});

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    return RedirectToAction("DiscountIndex" , new {productId = TempData["ProductId"]});
            }
        }


        public IActionResult RemoveDiscount(int mappingId)
        {
            var result = productDiscountService.DeleteMapping(mappingId);

            var tempdata = TempData["ProductId"];
            ViewData["ProductId"] = tempdata;
            TempData.Keep("ProductId");

            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("DiscountIndex" , new {productId = TempData["ProductId"]});

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    return RedirectToAction("DiscountIndex" , new { productId = TempData["ProductId"]});
            }
        }
        #endregion CRUD
    }
}
