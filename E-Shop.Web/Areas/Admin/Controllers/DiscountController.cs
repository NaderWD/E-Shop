using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.Services.DiscountServices;
using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class DiscountController(IDiscountService discountService) : AdminBaseController
    {
        public IActionResult DiscountIndex()
        {
            var content = discountService.GetAll();
            return View(content);
        }

        #region Add
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDiscount(DiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = discountService.CreateDiscount(model);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.DiscountAdded;
                return RedirectToAction("DiscountIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.DiscountFailMessage;
                return View(model);
            }
        }
        #endregion

        #region Update
        public IActionResult UpdateDiscount(int DiscountId)
        {
            var content = discountService.GetByIdForUpdate(DiscountId);
            return View(content);
        }

        [HttpPost]
        public IActionResult UpdateDiscount(UpdateDiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = discountService.UpdateDiscount(model);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.DiscountUpdate;
                return RedirectToAction("DiscountIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.DiscountFailMessage;
                return View(model);
            }
        }
        #endregion 

        public IActionResult DeleteDiscount(int Id)
        {
            var result = discountService.DeleteDiscount(Id);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.DiscountDeleted;
                return RedirectToAction("DiscountIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("DiscountIndex");
            }
        }
    }
}
