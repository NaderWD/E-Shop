using E_Shop.Domain.Models.UserModels;

namespace E_Shop.Domain.Models.RolePermissionModels
{
    public class UserRole : BaseModel
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
