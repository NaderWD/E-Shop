using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.ViewModels.Color;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ColorController(IColorService colorService) : AdminBaseController
    {
        public IActionResult ColorIndex()
        {
            var colors = colorService.GetAll();
            return View(colors);
        }

        
        public IActionResult CreateColor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateColor(ColorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            colorService.Create(model);
            return RedirectToAction("ColorViewModelList");
        }

        public IActionResult UpdateColor(int colorId)
        {
            var color = colorService.GetById(colorId);
            return View(color);
        }

        [HttpPost]
        public IActionResult UpdateColor(ColorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            colorService.Update(model);
            return RedirectToAction("ColorViewModelList");
        }

        [HttpPost]
        public IActionResult DeleteColor(int colorId)
        {
            colorService.Delete(colorId);
            return RedirectToAction("ColorViewModelList");
        }
    }

}
