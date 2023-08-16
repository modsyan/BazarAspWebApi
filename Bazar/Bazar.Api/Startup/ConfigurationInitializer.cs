namespace Bazar.Api.Startup;

public static class ConfigurationInitializer
{
    //Disabled write now
    public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        host.ConfigureAppConfiguration((context, builder) =>
        {
            builder.AddJsonFile("appsettings.json", false, true);
            builder.AddJsonFile($"appsettings.{environment}.json", true, true);
            builder.AddEnvironmentVariables();
        });
        return host;
    }
}