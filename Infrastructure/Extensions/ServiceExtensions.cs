using FluentValidation;
using Infrastructure.Configurations;
using Infrastructure.Mappings;
using Infrastructure.Queries.Handlers;
using Infrastructure.Reponsitories.Abstractions;
using Infrastructure.Reponsitories.Abstractions.Extend;
using Infrastructure.Reponsitories.Implementations;
using Infrastructure.Reponsitories.Implementations.Extend;
using Infrastructure.Services.Abstractions;
using Infrastructure.Services.Base;
using Infrastructure.Services.Implementations;
using Infrastructure.Validations.Extend;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            #region Repository
            // Repository
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            #region Service
            // Service
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IProductService, ProductService>();
            #endregion

            #region Validation
            // Validation
            services.AddValidatorsFromAssemblyContaining<ProductValidation>();
            #endregion

            #region MediatR
            // MediatR
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DeleteMultipleProductHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(DeleteProductHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(GetProductByIdHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(GetProductByPageHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(SaveProductHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(SearchProductElasticHandler).Assembly);
            });
            #endregion

            #region AutoMapper
            // AutoMapper
            var coreMappingAssembly = typeof(EntityMapping).Assembly;
            services.AddAutoMapper(coreMappingAssembly);
            #endregion

            #region Other
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
        }
        public static void AddDebugCustomService(this IServiceCollection services, IConfiguration configuration)
        {
        }

        public static void UseCustomService(this IApplicationBuilder app)
        {
        }
    }
}
