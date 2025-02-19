using E_Shop.Application.ViewModels.Color;
using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IColorService
    {
        bool Create(ColorViewModel color);
        bool Delete(int Id);
        bool Update(ColorViewModel color);

        ColorViewModel GetById(int Id);
        List<ColorViewModel> GetAll();
    }
}
