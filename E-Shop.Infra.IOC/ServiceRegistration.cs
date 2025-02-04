using E_Shop.Application.Services.Implementations;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Infra.Data;
using E_Shop.Infra.Data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Shop.Infra.IOC
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
