using E_Shop.Application.Services.AccountServices;
using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.Services.CommentService;
using E_Shop.Application.Services.ContactUsServices;
using E_Shop.Application.Services.DiscountServices;
using E_Shop.Application.Services.EmailServices;
using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.Services.RoleServices;
using E_Shop.Application.Services.SpecificationServices;
using E_Shop.Application.Services.TicketServices;
using E_Shop.Application.Services.UserServices;
using E_Shop.Application.Services.WalletServices;
using E_Shop.Domain.Contracts.ColorCont;
using E_Shop.Domain.Contracts.CommentCont;
using E_Shop.Domain.Contracts.ContactUsCont;
using E_Shop.Domain.Contracts.DiscountCont;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Contracts.RolePermissionCont;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Contracts.WalletCont;
using E_Shop.Infra.Data.Repositories.ColorRepo;
using E_Shop.Infra.Data.Repositories.CommentRepo;
using E_Shop.Infra.Data.Repositories.ContactUsRepo;
using E_Shop.Infra.Data.Repositories.DiscountRepo;
using E_Shop.Infra.Data.Repositories.Implementations;
using E_Shop.Infra.Data.Repositories.ProductRepo;
using E_Shop.Infra.Data.Repositories.RolePermissionRepo;
using E_Shop.Infra.Data.Repositories.SpecificationRepo;
using E_Shop.Infra.Data.Repositories.TicketRepo;
using E_Shop.Infra.Data.Repositories.UserRepo;
using E_Shop.Infra.Data.Repositories.WalletRepo;
using Microsoft.Extensions.DependencyInjection;

namespace E_Shop.Infra.IOC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddScoped<ITicketMessageRepository, TicketMessageRepository>();
            services.AddScoped<ITicketMessageService, TicketMessageService>();

            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();

            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
            services.AddScoped<IProductCategoriesService, ProductCategoriesService>();

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductService>();

            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();

            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductColorService, ProductColorService>();

            services.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
            services.AddScoped<IProductGalleryService, ProductGalleryService>();

            services.AddScoped<ISpecificationRepository, SpecificationRepository>();
            services.AddScoped<ISpecificationService, SpecificationService>();

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IProductRatingRepository, ProductRatingRepository>();
            services.AddScoped<IProductRatingService, ProductRatingService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IDiscountService, DiscountService>();

            services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();
            services.AddScoped<IProductDiscountService, ProductDiscountService>();

            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletService, WalletService>();

            return services;

        }
    }
}
