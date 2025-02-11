using E_Shop.Domain.Models;
using E_Shop.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;


namespace E_Shop.Infra.Data
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }



        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
