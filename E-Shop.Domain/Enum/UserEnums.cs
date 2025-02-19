using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Enum
{
    public static class UserEnums
    {
        public enum AvatarStatus
        {
            [Display(Name = "آنلاین")]
            Online,

            [Display(Name = "آفلاین")]
            Offline,

            [Display(Name = "مشغول")]
            Busy,
        }
    }
}
