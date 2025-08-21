using Ecommerce_Backend.Application.Abstractions.Services;
using Ecommerce_Backend.Application.Abstractions.Services.Authontication;
using Ecommerce_Backend.Application.Repositories;
using Ecommerce_Backend.Domain.Entities.Identity;
using Ecommerce_Backend.Persistence.Contexts;
using Ecommerce_Backend.Persistence.Repositories;
using Ecommerce_Backend.Persistence.Services;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<EcommerceDbContext>();
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IExternalAuthontication,AuthService>();
            services.AddScoped<IInternalAuthontication,AuthService>();



        }
    }
}
