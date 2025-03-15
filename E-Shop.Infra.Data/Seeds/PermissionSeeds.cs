using E_Shop.Domain.Models.RolePermissionModels;

namespace E_Shop.Infra.Data.Seeds
{
    public static class PermissionSeeds
    {
        public static List<Permission> ApplicationPermissions { get; } =
        [
            #region User
            new()
                {
                 ParentId = null,
                 Id = 1,
                 UniqName = PermissionName.UserManagement,
                 DisplayName = "مدیریت کاربران"
             },
             new()
             {
                 ParentId = 1,
                 Id = 2,
                 UniqName = PermissionName.CreateUser,
                 DisplayName = "ایجاد کاربر جدید"
             },
             new()
             {
                 ParentId = 1,
                 Id = 3,
                 UniqName = PermissionName.UserList,
                 DisplayName = "لیست کاربران"
             },
             new()
             {
                 ParentId = 1,
                 Id = 4,
                 UniqName = PermissionName.UpdateUser,
                 DisplayName = "بروز رسانی کاربران"
             },
             new()
             {
                 ParentId = 1,
                 Id = 5,
                 UniqName = PermissionName.DeleteUser,
                 DisplayName = "حذف کاربر"
             },
             #endregion
            
             #region Product
             new()
             {
                 ParentId = null,
                 Id = 6,
                 UniqName = PermissionName.ProductManagement,
                 DisplayName = "مدیریت محصولات"
             },
             new()
             {
                 ParentId = 6,
                 Id = 7,
                 UniqName = PermissionName.CreateProduct,
                 DisplayName = "ایجاد محصول جدید"
             },
             new()
             {
                 ParentId = 6,
                 Id = 8,
                 UniqName = PermissionName.ProductList,
                 DisplayName = "لیست محصولات"
             },
             new()
             {
                 ParentId = 6,
                 Id = 9,
                 UniqName = PermissionName.UpdateProduct,
                 DisplayName = "بروز رسانی محصولات"
             },
             new()
             {
                 ParentId = 6,
                 Id = 10,
                 UniqName = PermissionName.DeleteProduct,
                 DisplayName = "حذف محصول"
             },
             #endregion
            
             #region Color
             new()
             {
                 ParentId = null,
                 Id = 11,
                 UniqName = PermissionName.ColorManagement,
                 DisplayName = "مدیریت رنگ‌ها"
             },
             new()
             {
                 ParentId = 11,
                 Id = 12,
                 UniqName = PermissionName.CreateColor,
                 DisplayName = "ایجاد رنگ جدید"
             },
             new()
             {
                 ParentId = 11,
                 Id = 13,
                 UniqName = PermissionName.ColorList,
                 DisplayName = "لیست رنگ‌ها"
             },
             new()
             {
                 ParentId = 11,
                 Id = 14,
                 UniqName = PermissionName.UpdateColor,
                 DisplayName = "بروز رسانی رنگ‌ها"
             },
             new()
             {
                 ParentId = 11,
                 Id = 15,
                 UniqName = PermissionName.DeleteColor,
                 DisplayName = "حذف رنگ"
             },
             #endregion
            
             #region Comment
             new()
             {
                 ParentId = null,
                 Id = 16,
                 UniqName = PermissionName.CommentManagement,
                 DisplayName = "مدیریت نظرات"
             },
             new()
             {
                 ParentId = 16,
                 Id = 17,
                 UniqName = PermissionName.CommentList,
                 DisplayName = "لیست نظرات"
             },
             new()
             {
                 ParentId = 16,
                 Id = 18,
                 UniqName = PermissionName.ApproveComment,
                 DisplayName = "تایید نظر"
             },
             new()
             {
                 ParentId = 16,
                 Id = 19,
                 UniqName = PermissionName.DeleteComment,
                 DisplayName = "حذف نظر"
             },
             #endregion
            
             #region Contact Us
             new()
             {
                 ParentId = null,
                 Id = 20,
                 UniqName = PermissionName.ContactUsManagement,
                 DisplayName = "مدیریت تماس با ما"
             },
             new()
             {
                 ParentId = 20,
                 Id = 21,
                 UniqName = PermissionName.ContactUsList,
                 DisplayName = "لیست پیام‌های تماس"
             },
             new()
             {
                 ParentId = 20,
                 Id = 22,
                 UniqName = PermissionName.ReplyContactUs,
                 DisplayName = "پاسخ به پیام تماس"
             },
             new()
             {
                 ParentId = 20,
                 Id = 23,
                 UniqName = PermissionName.DeleteContactUs,
                 DisplayName = "حذف پیام تماس"
             },
             #endregion
            
             #region Discount
             new()
             {
                 ParentId = null,
                 Id = 24,
                 UniqName = PermissionName.DiscountManagement,
                 DisplayName = "مدیریت تخفیف‌ها"
             },
             new()
             {
                 ParentId = 24,
                 Id = 25,
                 UniqName = PermissionName.CreateDiscount,
                 DisplayName = "ایجاد تخفیف جدید"
             },
             new()
             {
                 ParentId = 24,
                 Id = 26,
                 UniqName = PermissionName.DiscountList,
                 DisplayName = "لیست تخفیف‌ها"
             },
             new()
             {
                 ParentId = 24,
                 Id = 27,
                 UniqName = PermissionName.UpdateDiscount,
                 DisplayName = "بروز رسانی تخفیف‌ها"
             },
             new()
             {
                 ParentId = 24,
                 Id = 28,
                 UniqName = PermissionName.DeleteDiscount,
                 DisplayName = "حذف تخفیف"
             },
             #endregion
            
             #region Role
             new()
             {
                 ParentId = null,
                 Id = 29,
                 UniqName = PermissionName.RoleManagement,
                 DisplayName = "مدیریت نقش‌ها"
             },
             new()
             {
                 ParentId = 29,
                 Id = 30,
                 UniqName = PermissionName.CreateRole,
                 DisplayName = "ایجاد نقش جدید"
             },
             new()
             {
                 ParentId = 29,
                 Id = 31,
                 UniqName = PermissionName.RoleList,
                 DisplayName = "لیست نقش‌ها"
             },
             new()
             {
                 ParentId = 29,
                 Id = 32,
                 UniqName = PermissionName.UpdateRole,
                 DisplayName = "بروز رسانی نقش‌ها"
             },
             new()
             {
                 ParentId = 29,
                 Id = 33,
                 UniqName = PermissionName.DeleteRole,
                 DisplayName = "حذف نقش"
             },
             new()
             {
                 ParentId = 29,
                 Id = 34,
                 UniqName = PermissionName.AssignPermissionsToRole,
                 DisplayName = "اختصاص مجوزها به نقش"
             },
             #endregion
            
             #region Ticket
             new()
             {
                 ParentId = null,
                 Id = 35,
                 UniqName = PermissionName.TicketManagement,
                 DisplayName = "مدیریت تیکت‌ها"
             },
             new()
             {
                 ParentId = 35,
                 Id = 36,
                 UniqName = PermissionName.CreateTicket,
                 DisplayName = "ایجاد تیکت جدید"
             },
             new()
             {
                 ParentId = 35,
                 Id = 37,
                 UniqName = PermissionName.TicketList,
                 DisplayName = "لیست تیکت‌ها"
             },
             new()
             {
                 ParentId = 35,
                 Id = 38,
                 UniqName = PermissionName.ReplyTicket,
                 DisplayName = "پاسخ به تیکت"
             },
             new()
             {
                 ParentId = 35,
                 Id = 39,
                 UniqName = PermissionName.CloseTicket,
                 DisplayName = "بستن تیکت"
             },
             new()
             {
                 ParentId = 35,
                 Id = 40,
                 UniqName = PermissionName.DeleteTicket,
                 DisplayName = "حذف تیکت"
             },
             #endregion
    ];
    }
}
