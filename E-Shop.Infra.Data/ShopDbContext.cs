using E_Shop.Domain.Models;
using E_Shop.Domain.Models.Products;
using E_Shop.Domain.Models.TiketModels;
using Microsoft.EntityFrameworkCore;


namespace E_Shop.Infra.Data
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
