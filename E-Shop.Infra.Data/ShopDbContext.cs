using E_Shop.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace E_Shop.Infra.Data
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }

    }
}
