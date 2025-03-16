using E_Shop.Application.Services.AddressServices;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.AddressViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class AddressController(IStateServices _stateServices, IAddressServices _addressServices, IUserAddressServices _userAddressServices) : UserBaseController
    {
        [HttpGet]
        public async Task<IActionResult> UserAddressList(int userId)
        {
            return View(await _addressServices.ShowAddressListByUserId(userId));
        }

        [HttpGet]
        public async Task<IActionResult> CreateAddress()
        {
            var states = await _stateServices.GetAllStates();
            ViewBag.States = new SelectList(states, "StateId", "StateName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressVM createAddressVM)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(CreateAddress));
            var userId = User.GetUserId();
            await _addressServices.CreateAddress(createAddressVM, userId);
            return RedirectToAction("");
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesByStateId(int stateId)
        {
            var cities = await _stateServices.GetAllCitiesOfState(stateId);
            return Json(cities.Select(c => new { c.CityId, c.CityName }));
        }


    }
}
