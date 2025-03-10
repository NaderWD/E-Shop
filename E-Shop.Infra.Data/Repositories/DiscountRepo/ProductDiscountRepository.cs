using E_Shop.Domain.Contracts.DiscountCont;
using E_Shop.Domain.Models.DiscountsModels;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.DiscountRepo
{
    public class ProductDiscountRepository(ShopDbContext dbContext) : IProductDiscountRepository
    {
        #region CRUD
        public bool AddMapping(DiscountProductMapping model)
        {
            dbContext.DiscountProductMapping.Add(model);
            dbContext.SaveChanges();
            return true;
        }
        public bool UpdateMapping(DiscountProductMapping model)
        {
            dbContext.DiscountProductMapping.Update(model);
            dbContext.SaveChanges();
            return true;
        }
        #endregion

        public List<DiscountProductMapping> GetAllForProduct(int productId)
        {
            return dbContext.DiscountProductMapping.Where(m => m.ProductId == productId && m.IsDelete == false).Include(m => m.Discount).ToList();
        }

        public async Task<List<DiscountProductMapping>> GetDiscountForProduct(int productId)
        {
            return await dbContext.DiscountProductMapping.Where(p => p.ProductId == productId).Include(m => m.Discount).ToListAsync();
        }

        public int GetProductPrice(int productId)
        {
            return dbContext.Products.Find(productId).Id;
        }

        public DiscountProductMapping GetByID(int discountId, int productId)
        {
            return dbContext.DiscountProductMapping.Where(m => m.ProductId == productId && m.DiscountId == discountId).FirstOrDefault();
        }

        public DiscountProductMapping GetByMappingID(int mappingId)
        {
            return dbContext.DiscountProductMapping.Find(mappingId);
        }

        public List<DiscountProductMapping> GetAll()
        {
            return dbContext.DiscountProductMapping.Where(m => m.IsDelete == false).Include(m => m.Discount).ToList();
        }

        public DiscountProductMapping GetLastPublicDiscount()
        {
            return dbContext.DiscountProductMapping.Where(d => d.IsAppliedToAll).OrderByDescending(d => d.CreateDate).FirstOrDefault();
        }
    }
}
