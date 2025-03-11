namespace E_Shop.Domain.Models.RolePermissionModels
{
    public class Permission : BaseModel
    {
        public string DisplayName { get; set; }                    
        public string UniqName { get; set; }

        public int? ParentId { get; set; }   
        public Permission Parent { get; set; }      

        public IEnumerable<RolePermission>? RolePermissions { get; set; }
    }
}
