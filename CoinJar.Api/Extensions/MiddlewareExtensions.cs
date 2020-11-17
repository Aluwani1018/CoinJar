using CoinJar.Core.Uow;
using CoinJar.Data;
using CoinJar.Data.Uow;
using CoinJar.Service.Services;
using CoinJar.Service.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace CoinJar.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coin Api Documentation",
                    Description = "This documentation provides information about Coin Jar Api endpoints",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Aluwani Mathode",
                        Email = "mathode.alu@gmail.com"
                    },
                });
                x.EnableAnnotations();
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Coin Jar Api");
                options.DocumentTitle = "Coin Jar Api";
            });

            return app;
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CoinJar.Data")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICoinService, CoinService>();

            return services;
        }
    }
}
