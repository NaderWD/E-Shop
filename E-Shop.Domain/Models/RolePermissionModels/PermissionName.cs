namespace E_Shop.Domain.Models.RolePermissionModels
{
    public static class PermissionName
    {
        #region User
        public const string UserManagement = "UserManagement";
        public const string CreateUser = "CreateUser";
        public const string UserList = "UserList";
        public const string UpdateUser = "UpdateUser";
        public const string DeleteUser = "DeleteUser";
        #endregion

        #region Product
        public const string ProductManagement = "ProductManagement";
        public const string CreateProduct = "CreateProduct";
        public const string ProductList = "ProductList";
        public const string UpdateProduct = "UpdateProduct";
        public const string DeleteProduct = "DeleteProduct";
        #endregion

        #region Color
        public const string ColorManagement = "ColorManagement";
        public const string CreateColor = "CreateColor";
        public const string ColorList = "ColorList";
        public const string UpdateColor = "UpdateColor";
        public const string DeleteColor = "DeleteColor";
        #endregion

        #region Comment
        public const string CommentManagement = "CommentManagement";
        public const string CommentList = "CommentList";
        public const string ApproveComment = "ApproveComment";
        public const string DeleteComment = "DeleteComment";
        #endregion

        #region Contact Us
        public const string ContactUsManagement = "ContactUsManagement";
        public const string ContactUsList = "ContactUsList";
        public const string ReplyContactUs = "ReplyContactUs";
        public const string DeleteContactUs = "DeleteContactUs";
        #endregion

        #region Discount
        public const string DiscountManagement = "DiscountManagement";
        public const string CreateDiscount = "CreateDiscount";
        public const string DiscountList = "DiscountList";
        public const string UpdateDiscount = "UpdateDiscount";
        public const string DeleteDiscount = "DeleteDiscount";
        #endregion

        #region Role
        public const string RoleManagement = "RoleManagement";
        public const string CreateRole = "CreateRole";
        public const string RoleList = "RoleList";
        public const string UpdateRole = "UpdateRole";
        public const string DeleteRole = "DeleteRole";
        public const string AssignPermissionsToRole = "AssignPermissionsToRole";
        #endregion

        #region Ticket
        public const string TicketManagement = "TicketManagement";
        public const string CreateTicket = "CreateTicket";
        public const string TicketList = "TicketList";
        public const string ReplyTicket = "ReplyTicket";
        public const string CloseTicket = "CloseTicket";
        public const string DeleteTicket = "DeleteTicket";
        #endregion
    }
}
