using Bazar.Api.Helpers;
using Bazar.Api.Middlewares;
using Bazar.Api.Services;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Contracts;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Repositories;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bazar.Api.Startup;

public static class ServiceExtensions
{
    public static IServiceCollection SingletonServicesRegistrar(this IServiceCollection service)
    {
        return service;
    }

    public static IServiceCollection ConfigurationServicesRegistrar(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));
        services.Configure<ExternalAuthOptions>(configuration.GetSection(ExternalAuthOptions.ExternalAuth));

        return services;
    }

    public static IServiceCollection TransitServicesRegistrar(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfiguration>();
        
        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<GlobalExceptionMiddleware>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IFaqService, FaqService>();

        return services;
    }

    public static IServiceCollection ScopedServicesRegistrar(this IServiceCollection services)
    {
        return services;
    }
}