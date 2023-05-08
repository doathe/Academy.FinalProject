using ECommerce.Infrastructure.EFCore.Context;
using ECommerce.Infrastructure.EFCore.Repository;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ECommerce.Infrastructure.EFCore.Repositories.Interfaces;
using ECommerce.Infrastructure.EFCore.Repositories;

namespace ECommerce.Infrastructure.EFCore
{
    public static class DependencyInjection
    {
        public static void AddEFCoreDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is null or empty.");
            }
            services.AddDbContext<ECommerceDbContext>(option => option.UseSqlServer(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }
    }
}
