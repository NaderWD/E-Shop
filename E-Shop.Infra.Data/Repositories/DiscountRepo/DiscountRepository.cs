using E_Shop.Domain.Contracts.DiscountCont;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.DiscountRepo
{
    public class DiscountRepository(ShopDbContext dbContext) : IDiscountRepository
    {
        #region CRUD
        public bool CreateDiscount(Discount discount)
        {
            Discount model = new Discount()
            {
                DiscountPercentage = discount.DiscountPercentage,
                EndDate = discount.EndDate,
                StartDate = discount.StartDate,
                CreateDate = discount.CreateDate,
                Code = discount.Code,
                IsActive = discount.IsActive,
                LastModifiedDate = discount.LastModifiedDate,
                DiscountAmount = discount.DiscountAmount,

            };

            dbContext.Discounts.Add(model);
            dbContext.SaveChanges();

            return true;
        }

        public bool UpdateDiscount(Discount model)
        {
            dbContext.Discounts.Update(model);
            dbContext.SaveChanges();
            return true;
        }
        #endregion
        public List<Discount> GetAll()
        {
            return dbContext.Discounts.Where(d => d.IsDelete == false).ToList();
        }

        public Discount GetById(int Id)
        {
            return dbContext.Discounts.Find(Id);
        }


    }
}
