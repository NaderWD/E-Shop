namespace E_Shop.Application.ViewModels.RoleViewModels
{
    #region Role
    public class RoleVM
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string>? PermissionNames { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    #endregion

    #region RolePermission
    public class RolePermissionVMForShow
    {
        public string RoleName { get; set; }
        public List<int>? SelectedPermissions { get; set; } = [];
    }

    public class PermissionVM
    {
        public int PermissionId { get; set; }
        public string DisplayName { get; set; }
        public string UniqName { get; set; }
        public int? ParentId { get; set; }
        public bool IsSelected { get; set; }
        public List<PermissionVM>? Children { get; set; }
    }
    #endregion

    #region For Detail
    public class RoleDetailsVM
    {
        public string RoleName { get; set; }
        public List<PermissionForDetailVM>? Permissions { get; set; }
    }

    public class PermissionForDetailVM
    {
        public int PermissionId { get; set; }
        public string DisplayName { get; set; }
        public List<PermissionForDetailVM>? Children { get; set; }
    }
    #endregion

    #region For Edit
    public class RoleEditVM
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<int>? SelectedPermissions { get; set; }
    }
    #endregion

    #region User Role
    public class UserRoleVM
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }                      
        public List<string>? RolesName { get; set; }        
        public List<int>? SelectedRoles { get; set; }
    }
    #endregion
}
