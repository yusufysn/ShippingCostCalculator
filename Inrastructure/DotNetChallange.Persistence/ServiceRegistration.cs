using DotNetChallange.Application.Abstractions;
using DotNetChallange.Persistence.Concretes;
using DotNetChallange.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetChallange.Persistence.Repositories;
using DotNetChallange.Application.Repositories;

namespace DotNetChallange.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<DotNetChallangeDbContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DotNetChallangeDb;Trusted_Connection=True;TrustServerCertificate=True"));
            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        }
    }
}
