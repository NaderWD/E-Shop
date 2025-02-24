using E_Shop.Application.Services.AccountServices;
using E_Shop.Application.Services.ContactUsServices;
using E_Shop.Application.Services.EmailServices;
using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.Services.SpecificationServices;
using E_Shop.Application.Services.TicketServices;
using E_Shop.Application.Services.UserServices;
using E_Shop.Domain.Contracts.ContactUsCont;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Infra.Data.Repositories.ContactUsRepo;
using E_Shop.Infra.Data.Repositories.ProductRepo;
using E_Shop.Infra.Data.Repositories.SpecificationRepo;
using E_Shop.Infra.Data.Repositories.TicketRepo;
using E_Shop.Infra.Data.Repositories.UserRepo;
using Microsoft.Extensions.DependencyInjection;
using E_Shop.Domain.Contracts.ColorCont;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Application.Services.ColorServices;
using E_Shop.Infra.Data.Repositories.ColorRepo;
using E_Shop.Infra.Data.Repositories.Implementations;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.Implementations;

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

            services.AddScoped<ISpecificationRepository, SpecificationRepository>();
            services.AddScoped<IProductSpecificationRepository, ProductSpecificationRepository>();
            services.AddScoped<ISpecificationService, SpecificationService>();

            return services;
        }
    }
}
