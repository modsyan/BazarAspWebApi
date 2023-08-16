using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bazar.Api.Startup;

public static class StartupServices
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services , IConfiguration configuration)
    {
        services.DbContextRegistrar(configuration);
        
        services.CorsRegistrar();
        
        services.ConfigurationServicesRegistrar(configuration);
        
        services.TransitServicesRegistrar();
        
        services.ScopedServicesRegistrar();
        
        services.SingletonServicesRegistrar();
        
        services.IdentityRegistrar();
        
        services.AddAutoMapper(typeof(Program).Assembly);
        
        services.AuthenticationRegistrar(configuration);
        
        services.AddControllers();
        
        services.LimiterRegistrar();
        
        services.AddSwaggerGen();
        
        services.AddEndpointsApiExplorer();

        return services;
    }
}