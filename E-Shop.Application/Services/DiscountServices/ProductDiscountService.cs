using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.DiscountCont;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Shop.Application.Services.DiscountServices
{
    public class ProductDiscountService(IProductDiscountRepository _proDiscountRepository, IDiscountRepository _discountRepository) : IProductDiscountService
    {
        public bool AddMapping(AddMappingViewModel mapping)
        {
            DiscountProductMapping model = new DiscountProductMapping();
            model.ProductId = mapping.ProductId;
            model.IsAppliedToAll = mapping.IsAppliedToAll;
            model.DiscountId = mapping.DiscountId;
            model.CreateDate = DateTime.Now;

            return _proDiscountRepository.AddMapping(model);
        }
        public bool DeleteMapping(int mappingId)
        {
            var mapping = _proDiscountRepository.GetByMappingID(mappingId);
            mapping.IsDelete = true;
            return _proDiscountRepository.UpdateMapping(mapping);
        }
        public bool UpdateMapping(UpdateMappingViewModel mapping)
        {
            var model = _proDiscountRepository.GetByMappingID(mapping.Id);
            model.LastModifiedDate = DateTime.Now;
            model.DiscountId = mapping.DiscountId;
            model.ProductId = mapping.ProductId;
            model.IsAppliedToAll = mapping.IsAppliedToAll;

            return _proDiscountRepository.UpdateMapping(model);

        }



        public int ApplyDiscount(List<DiscountsViewModel> query, int price)
        {
            var date = DateTime.Now;
            if (query.Where(p => p.IsActive == true).Any())
            {
                if (query.Where(p => p.Code == null).Any())
                {
                    if (query.Where(d => d.StartDate != null && d.EndDate != null).Any())
                    {
                        if (query.Where(d => d.StartDate <= date && d.EndDate >= date).Any())
                        {
                            var discount = query.OrderByDescending(m => m.StartDate).First();
                            if (query.Where(d => d.DiscountPercentage != null && d.DiscountAmount != null).Any())
                            {
                                if (price - discount.DiscountAmount < price * (double)(discount.DiscountPercentage / 100))
                                {
                                    if (price * (double)(discount.DiscountPercentage / 100) > 0)
                                    {
                                        return (int)(price * (double)(discount.DiscountPercentage / 100));
                                    }
                                    else
                                    {
                                        return price;
                                    }
                                }
                                else
                                {
                                    if (price - discount.DiscountAmount.Value! < 0)
                                    {
                                        return price - discount.DiscountAmount.Value;
                                    }
                                    else
                                    {
                                        return price;
                                    }
                                }
                            }
                            else if (query.Where(d => d.DiscountPercentage == null && d.DiscountAmount != null).Any())
                            {
                                if (price - discount.DiscountAmount.Value > 0)
                                {
                                    return price - discount.DiscountAmount.Value;
                                }
                                else
                                {
                                    return price;
                                }
                            }
                            else
                            {
                                if (price * (double)(discount.DiscountPercentage / 100) > 0)
                                {
                                    return (int)(price * (double)(discount.DiscountPercentage / 100));
                                }
                                else
                                {
                                    return price;
                                }
                            }
                        }
                        else
                        {
                            return price;
                        }
                    }
                    else
                    {
                        var discount = query.First();
                        if (query.Where(d => d.DiscountPercentage != null && d.DiscountAmount != null).Any())
                        {
                            if (price - discount.DiscountAmount > price * (double)(discount.DiscountPercentage / 100))
                            {
                                if (price * (double)(discount.DiscountPercentage / 100) > 0)
                                {
                                    return (int)(price * (double)(discount.DiscountPercentage / 100));
                                }
                                else
                                {
                                    return price;
                                }
                            }
                            else
                            {
                                if (price - discount.DiscountAmount.Value > 0)
                                {
                                    return price - discount.DiscountAmount.Value;
                                }
                                else
                                {
                                    return price;
                                }
                            }
                        }
                        else if (query.Where(d => d.DiscountPercentage == null && d.DiscountAmount != null).Any())
                        {
                            if (price - discount.DiscountAmount.Value > 0)
                            {
                                return price - discount.DiscountAmount.Value;
                            }
                            else
                            {
                                return price;
                            }
                        }
                        else
                        {
                            if (price * (double)(discount.DiscountPercentage / 100) > 0)
                            {
                                return (int)(price * (double)(discount.DiscountPercentage / 100));
                            }
                            else
                            {
                                return price;
                            }
                        }
                    }


                }
                else
                {
                    return price;
                }

            }
            else
            {
                return price;
            }
        }

        public int ApplypublicDiscount(DiscountProductMapping publicDiscount, int price)
        {
            if (publicDiscount.Discount.DiscountPercentage != null && publicDiscount.Discount.DiscountAmount != null)
            {
                var o = ((double)publicDiscount.Discount.DiscountPercentage.Value / 100);
                var q = price - publicDiscount.Discount.DiscountAmount;
                var p = price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100);
                if (price - publicDiscount.Discount.DiscountAmount < price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100))
                {

                    if (price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100) > 0)
                    {
                        return (int)(price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100));
                    }
                    else
                    {
                        return price;
                    }
                }
                else
                {
                    if (price - publicDiscount.Discount.DiscountAmount.Value > 0)
                    {
                        return price - publicDiscount.Discount.DiscountAmount.Value;
                    }
                    else
                    {
                        return price;
                    }
                }
            }
            else if (publicDiscount.Discount.DiscountPercentage == null && publicDiscount.Discount.DiscountAmount != null)
            {
                if (price - publicDiscount.Discount.DiscountAmount.Value > 0)
                {
                    return price - publicDiscount.Discount.DiscountAmount.Value;
                }
                else
                {
                    return price;
                }
            }
            else
            {
                if (price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100) > 0)
                {
                    return (int)(price * ((double)publicDiscount.Discount.DiscountPercentage.Value / 100));
                }
                else
                {
                    return price;
                }
            }
        }


        public List<DiscountViewModel> GetAllForProduct(int productId)
        {
            var discounts = _proDiscountRepository.GetAllForProduct(productId);
            List<DiscountViewModel> models = new List<DiscountViewModel>();

            foreach (var item in discounts)
            {
                models.Add(new DiscountViewModel
                {
                    Id = item.Id,
                    Code = item.Discount.Code,
                    CreateDate = item.CreateDate,
                    DiscountAmount = item.Discount.DiscountAmount,
                    DiscountPercentage = item.Discount.DiscountPercentage,
                    StartDate = item.Discount.StartDate,
                    EndDate = item.Discount.EndDate,
                    IsActive = item.Discount.IsActive,
                    IsAppliedToAll = item.IsAppliedToAll,

                });
            }
            return models;
        }

        public List<DiscountViewModel> GetDiscountForProduct(int productId)
        {
            var discounts = _proDiscountRepository.GetDiscountForProduct(productId);
            List<DiscountViewModel> models = new List<DiscountViewModel>();

            if (discounts.Count != 0)
            {
                foreach (var item in discounts)
                {
                    models.Add(new DiscountViewModel
                    {
                        Code = item.Discount.Code,
                        DiscountAmount = item.Discount.DiscountAmount,
                        DiscountPercentage = item.Discount.DiscountPercentage,
                        Id = item.Discount.Id,
                        StartDate = item.Discount.StartDate,
                        EndDate = item.Discount.EndDate,
                        IsAppliedToAll = item.IsAppliedToAll,
                        IsActive = item.Discount.IsActive,
                        CreateDate = item.CreateDate,

                    });
                }

                return models;
            }
            else
            {
                models = new List<DiscountViewModel>();
                return models;
            }

        }

        public DiscountViewModel GetById(int discountId, int productId)
        {
            var dicount = _proDiscountRepository.GetByID(discountId, productId);
            DiscountViewModel model = new DiscountViewModel()
            {
                Id = dicount.DiscountId,
                Code = dicount.Discount.Code,
                CreateDate = dicount.CreateDate,
                DiscountAmount = dicount.Discount.DiscountAmount,
                DiscountPercentage = dicount.Discount.DiscountPercentage,
                StartDate = dicount.Discount.StartDate,
                EndDate = dicount.Discount.EndDate,
                IsActive = dicount.Discount.IsActive,
                IsAppliedToAll = dicount.IsAppliedToAll,
            };
            return model;

        }

        public List<DiscountsSelectViewModel> GetAllSelect()
        {
            var discounts = _discountRepository.GetAll();
            List<DiscountsSelectViewModel> model = new List<DiscountsSelectViewModel>();

            foreach (var item in discounts)
            {
                model.Add(new DiscountsSelectViewModel
                {
                    Code = item.Code,
                    DiscountAmount = item.DiscountAmount,
                    DiscountPercentage = item.DiscountPercentage,
                    Id = item.Id,
                });
            }
            return model;
        }

        public UpdateMappingViewModel GetByMappingID(int mappingId)
        {
            var mapping = _proDiscountRepository.GetByMappingID(mappingId);
            UpdateMappingViewModel model = new UpdateMappingViewModel()
            {
                DiscountId = mapping.DiscountId,
                ProductId = mapping.ProductId,
                Id = mapping.Id,
                IsAppliedToAll = mapping.IsAppliedToAll,
            };

            return model;
        }

        public int ApplypublicDiscountByVM(DiscountViewModel publicDiscount, int price)
        {
            if (publicDiscount.DiscountPercentage != null && publicDiscount.DiscountAmount != null)
            {
                var o = ((double)publicDiscount.DiscountPercentage.Value / 100);
                var q = price - publicDiscount.DiscountAmount;
                var p = price * ((double)publicDiscount.DiscountPercentage.Value / 100);
                if (price - publicDiscount.DiscountAmount < price * ((double)publicDiscount.DiscountPercentage.Value / 100))
                {

                    if (price * ((double)publicDiscount.DiscountPercentage.Value / 100) > 0)
                    {
                        return (int)(price * ((double)publicDiscount.DiscountPercentage.Value / 100));
                    }
                    else
                    {
                        return price;
                    }
                }
                else
                {
                    if (price - publicDiscount.DiscountAmount.Value > 0)
                    {
                        return price - publicDiscount.DiscountAmount.Value;
                    }
                    else
                    {
                        return price;
                    }
                }
            }
            else if (publicDiscount.DiscountPercentage == null && publicDiscount.DiscountAmount != null)
            {
                if (price - publicDiscount.DiscountAmount.Value > 0)
                {
                    return price - publicDiscount.DiscountAmount.Value;
                }
                else
                {
                    return price;
                }
            }
            else
            {
                if (price * ((double)publicDiscount.DiscountPercentage.Value / 100) > 0)
                {
                    return (int)(price * ((double)publicDiscount.DiscountPercentage.Value / 100));
                }
                else
                {
                    return price;
                }
            }
        }
    }
}
