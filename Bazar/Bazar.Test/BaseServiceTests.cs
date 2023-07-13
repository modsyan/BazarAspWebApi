using Bazar.Core.Interfaces;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Test;

public abstract class BaseServiceTests<TService> where TService: class
{
    protected TService Service { get; }

    protected BaseServiceTests()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath("/home/modsyan/projects/RiderProjects/BazarASPWebAPI/Bazar/Bazar.Api/")
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(
                    typeof(ApplicationDbContext).Assembly.FullName
                )
            )
        );

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        
        AddServices(services);
        
        var serviceProvider = services.BuildServiceProvider();
        Service = serviceProvider.GetRequiredService<TService>();
    }
    
    protected abstract void AddServices(IServiceCollection services);
}