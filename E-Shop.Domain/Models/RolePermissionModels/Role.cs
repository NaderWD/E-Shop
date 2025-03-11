namespace E_Shop.Domain.Models.RolePermissionModels
{
    public class Role : BaseModel
    {
        public string RoleName { get; set; }         

        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<RolePermission>? RolePermissions { get; set; } 
    }
}
