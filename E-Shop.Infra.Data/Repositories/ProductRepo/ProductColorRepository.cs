using E_Shop.Domain.Contracts.ColorCont;
using E_Shop.Domain.Models;
using E_Shop.Domain.Models.ColorModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ProductColorRepository(ShopDbContext dbContext) : IProductColorRepository
    {
        public bool AddMapping(ProductColorMapping model)
        {
            dbContext.ProductColorMapping.Add(model);
            dbContext.SaveChanges();
            return true;
        }

        public List<ProductColorMapping> GetAllColorForProduct(int productId)
        {
            return dbContext.ProductColorMapping.Where(m => m.ProductId == productId).Include(p => p.Product).Include(c => c.Color).ToList();
        }

        public ProductColorMapping GetById(int id)
        {
            return dbContext.ProductColorMapping.Find(id);
        }

        public bool Update(ProductColorMapping model)
        {
            dbContext.ProductColorMapping.Update(model);
            return true;
        }

    }
}
