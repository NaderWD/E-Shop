using E_Shop.Domain.Models.ColorModels;
using E_Shop.Domain.Models.CommentModels;
using E_Shop.Domain.Models.ContactUsModels;
using E_Shop.Domain.Models.DiscountsModels;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.RolePermissionModels;
using E_Shop.Domain.Models.SpecificationModels;
using E_Shop.Domain.Models.TicketModels;
using E_Shop.Domain.Models.UserModels;
using E_Shop.Infra.Data.Seeds;
using E_Shop.Domain.Models.Wallet;
using Microsoft.EntityFrameworkCore;
using E_Shop.Domain.Models.Order;
using E_Shop.Domain.Models.AddressModels;


namespace E_Shop.Infra.Data
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        #region User
        public DbSet<User> Users { get; set; }
        #endregion

        #region ContactUs
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        #endregion

        #region Ticket
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        #endregion

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductColorMapping> ProductColorMapping { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductGallery> ProductGallery { get; set; }
        #endregion

        #region Color
        public DbSet<ColorModel> Color { get; set; }
        #endregion

        #region specification
        public DbSet<Specification> Specifications { get; set; }

        public DbSet<CategorySpecification> CategorySpecifications { get; set; }
        #endregion

        #region Comments
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        #endregion

        #region discount
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountProductMapping> DiscountProductMapping { get; set; }
        #endregion

        #region Roles and Permissions
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }                        
        public DbSet<Address> Addresses { get; set; }         
        public DbSet<UserAddress> UserAddresses { get; set; }


        #region Money
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the permissions
            modelBuilder.Entity<Permission>().HasData(PermissionSeeds.ApplicationPermissions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
