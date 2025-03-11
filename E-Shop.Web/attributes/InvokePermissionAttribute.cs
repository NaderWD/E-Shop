using E_Shop.Application.Services.RoleServices;
using E_Shop.Application.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Shop.Web.attributes
{
    public class InvokePermissionAttribute(string permissionName) : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var permissionService = context.HttpContext.RequestServices.GetRequiredService<IRolePermissionService>();
            var userId = context.HttpContext.User.GetUserId();
            bool userHaveAccess = await permissionService.CheckUserPermissionAsync(userId, permissionName);
            if (!userHaveAccess)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.HttpContext.Response.Redirect("/");
            }
        }
    }
}
