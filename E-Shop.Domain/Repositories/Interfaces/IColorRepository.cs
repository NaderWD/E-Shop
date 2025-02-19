using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IColorRepository
    {
        bool Create(ColorModel color);
        bool Delete(int Id);
        bool Update(ColorModel color);

        ColorModel GetById(int Id);
        List<ColorModel> GetAll();

    }
}
