using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bazar.Api.Startup;

public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(name: "v1", info: new OpenApiInfo
        {
            Version = "v1",
            Title = "BazarApi",
            Contact = new OpenApiContact
            {
                Name = "Muhammad Hamdy",
                Email = "modclover7@gamil.com",
            },
            Description =
                "Bazar 'Handmade social media e-commerce application'",
            TermsOfService = new Uri("https://www.BazarCraftting.com/License"),
            License = new OpenApiLicense
            {
                Name = "Bazar Company Licence Name",
                Url = new Uri("https://www.BazarCraftting.com/"),
            }
        });

        options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "usage: \"Bearer [TOKEN]\"",
            Name = "JWT Authentication",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    }
}