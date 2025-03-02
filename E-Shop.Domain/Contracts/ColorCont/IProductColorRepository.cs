using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shop.Domain.Models.ColorModels;

namespace E_Shop.Domain.Contracts.ColorCont
{
    public interface IProductColorRepository
    {
        public List<ProductColorMapping> GetAllColorForProduct(int productId);
        ProductColorMapping GetById(int id);
        bool Update(ProductColorMapping model);
        bool AddMapping(ProductColorMapping model);


    }
}
