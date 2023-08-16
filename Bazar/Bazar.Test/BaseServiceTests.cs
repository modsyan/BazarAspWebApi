using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bazar.Api.Startup;

namespace Bazar.Test;

public abstract class BaseServiceTests<TService> where TService : class
{
    protected TService Service { get; }


    protected BaseServiceTests()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath("/home/modsyan/projects/RiderProjects/BazarASPWebAPI/Bazar/Bazar.Api/")
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        services.AddLogging();

        services.TransitServicesRegistrar();
        services.DbContextRegistrar(configuration: configuration);
        services.IdentityRegistrar();
        
        
        services.AddSingleton<IConfiguration>(configuration);


        var serviceProvider = services.BuildServiceProvider();
        Service = serviceProvider.GetRequiredService<TService>();
    }
}