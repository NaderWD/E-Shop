using E_Shop.Application.Services.AddressServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class AddressController(IStateServices _stateServices, IAddressServices _addressServices) : UserBaseController
    {
        #region Address
        [HttpGet]
        public async Task<IActionResult> UserAddressList(int userId)
        {
            return View(await _addressServices.GetUsersAddressesByUserId(userId));
        }

        [HttpGet]
        public async Task<IActionResult> CreateAddress()
        {
            ViewBag.States = await _stateServices.GetAllStates();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(int userId)
        {
            
            return View();
        }
        #endregion
    }
}
