using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Components
{
    public class ChatHistoriesViewComponent() : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}