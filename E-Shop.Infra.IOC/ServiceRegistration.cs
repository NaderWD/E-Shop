using E_Shop.Application.Services.Implementations;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.Contracts.ContactUsCont;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Infra.Data.Repositories.ContactUsRepo;
using E_Shop.Infra.Data.Repositories.ProductRepo;
using E_Shop.Infra.Data.Repositories.TicketRepo;
using E_Shop.Infra.Data.Repositories.UserRepo;
using Microsoft.Extensions.DependencyInjection;

namespace E_Shop.Infra.IOC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

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

            return services;
        }
    }
}
