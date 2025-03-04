using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Domain.Contracts.DiscountCont;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.DiscountServices
{
    public class DiscountService(IDiscountRepository discountRepository) : IDiscountService
    {
        #region CRUD
        public bool CreateDiscount(DiscountViewModel discount)
        {
            Discount model = new Discount();
            if (discount.DiscountAmount != null && discount.DiscountPercentage != null)
            {
                model.DiscountPercentage = discount.DiscountPercentage;
                model.EndDate = discount.EndDate;
                model.StartDate = discount.StartDate;
                model.CreateDate = discount.CreateDate;
                model.Code = discount.Code;
                model.IsActive = discount.IsActive;
                model.LastModifiedDate = discount.LastModifiedDate;
                model.DiscountAmount = discount.DiscountAmount;
                discountRepository.CreateDiscount(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateDiscount(UpdateDiscountViewModel discount)
        {
            var model = discountRepository.GetById(discount.Id);
            if (discount.DiscountAmount != null && discount.DiscountPercentage != null)
            {
                model.DiscountPercentage = discount.DiscountPercentage;
                model.EndDate = discount.EndDate;
                model.StartDate = discount.StartDate;
                model.CreateDate = discount.CreateDate;
                model.Code = discount.Code;
                model.IsActive = discount.IsActive;
                model.LastModifiedDate = discount.LastModifiedDate;
                model.DiscountAmount = discount.DiscountAmount;
                discountRepository.CreateDiscount(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public List<DiscountViewModel> GetAll()
        {
            var discounts = discountRepository.GetAll();
            List<DiscountViewModel> models = new List<DiscountViewModel>();

            foreach (var item in discounts)
            {
                models.Add(new DiscountViewModel
                {
                    Id = item.Id,
                    DiscountPercentage = item.DiscountPercentage,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    CreateDate = item.CreateDate,
                    Code = item.Code,
                    IsActive = item.IsActive,
                    LastModifiedDate = item.LastModifiedDate,
                    DiscountAmount = item.DiscountAmount,
                });
            }
            return models;
        }

        public DiscountViewModel GetById(int Id)
        {
            var discount = discountRepository.GetById(Id);
            DiscountViewModel model = new DiscountViewModel()
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

            return model;
        }


    }
}
