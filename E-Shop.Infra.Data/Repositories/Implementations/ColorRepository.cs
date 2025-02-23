using E_Shop.Domain.Contracts.Colors;
using E_Shop.Domain.Models.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ColorRepository(ShopDbContext dbContext) : IColorRepository
    {

        public List<ColorModel> GetAll()
        {
            return dbContext.Color.ToList();
        }

        public ColorModel GetById(int Id)
        {
            return dbContext.Color.Find(Id);
        }


        public bool Create(ColorModel color)
        {
            dbContext.Add(color);
            dbContext.SaveChanges();
            return true;
        }
        public bool Update(ColorModel color)
        {
            dbContext.Update(color);
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
