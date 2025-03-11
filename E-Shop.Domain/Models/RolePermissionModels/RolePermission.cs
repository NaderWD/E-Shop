namespace E_Shop.Domain.Models.RolePermissionModels
{
    public class RolePermission : BaseModel
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
