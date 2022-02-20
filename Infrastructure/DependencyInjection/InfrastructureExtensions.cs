﻿using Application.Database.Repository;
using Infrastructure.Database;
using Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddServices();
            services.AddDataBase();
            return services;
        }

        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        internal static void AddDataBase(this IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(x => x.UseInMemoryDatabase("Database"));
            services.AddScoped<ProductContext, ProductContext>();
        }
    }
}
