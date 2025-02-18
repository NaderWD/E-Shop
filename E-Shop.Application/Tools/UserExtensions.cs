using System.Security.Claims;
using System.Security.Principal;

namespace E_Shop.Application.Tools
{
    public static class UserExtensions
    {
        #region ID
        public static int GetUserId(this ClaimsPrincipal claims)
        {
            if (int.TryParse(claims.FindFirst(ClaimTypes.NameIdentifier).Value, out int id)) return id;
            return 0;
        }

        public static int GetUserId(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claim) return claim.GetUserId();
            return 0;
        }
        #endregion



        #region Email
        public static string GetUserEmail(this ClaimsPrincipal userEmail)
        {
            var userEmailClaim = userEmail.FindFirst(ClaimTypes.Email);
            return userEmailClaim != null ? userEmailClaim.Value : string.Empty;
        }

        public static string GetUserEmail(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal userEmail) return userEmail.GetUserEmail();
            return string.Empty;
        }
        #endregion



        #region Name
        public static string GetUsersName(this ClaimsPrincipal usersName)
        {
            var firstNameClaim = usersName.FindFirst(ClaimTypes.Name);
            return firstNameClaim != null ? firstNameClaim.Value : string.Empty;
        }

        public static string GetUsersName(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal usersName) return usersName.GetUsersName();
            return string.Empty;
        }
        #endregion



        #region Admin Check
        public static bool AdminCheck(this ClaimsPrincipal adminCheck)
        {
            var admin = adminCheck.FindFirst(ClaimTypes.Role);
            return admin != null;
        }

        public static bool AdminCheck(this IPrincipal principal)
        {
            if (principal is ClaimsPrincipal) return true;
            return false;
        }
        #endregion
    }
}
