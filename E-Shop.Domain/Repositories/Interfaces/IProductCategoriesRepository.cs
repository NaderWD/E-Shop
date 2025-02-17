using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IProductCategoriesRepository
    {
        List<ProductCategories> GetAll();
        ProductCategories GetProductCategoryById(int Id);

        bool CreateProductCategory(ProductCategories model);
        bool UpdateProductCategory(ProductCategories model);
        bool Save();
        
       
    }
}
