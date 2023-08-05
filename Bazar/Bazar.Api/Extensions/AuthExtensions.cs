using System.Text;
using Bazar.Api.Helpers;
using Bazar.Core.Constants;
using Bazar.Core.Entities;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Extensions;

public static class AuthExtensions
{
    public static IServiceCollection DbContextRegistrar(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(
                    typeof(ApplicationDbContext).Assembly.FullName)
            )
        );
    }

    public static IServiceCollection AuthenticationRegistrar(this IServiceCollection services,
        IConfiguration configuration)
    {
        var externalsAuthOptions = new ExternalAuthOptions();
        var jwtOptions = new JwtOptions();
        configuration.GetSection(ExternalAuthOptions.ExternalAuth).Bind(externalsAuthOptions);
        configuration.GetSection(JwtOptions.Jwt).Bind(jwtOptions);

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(jwtOptions.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            })
            .AddTwitter(option =>
            {
                option.ConsumerKey = externalsAuthOptions.TwitterClientId;
                option.ConsumerSecret = externalsAuthOptions.TwitterClientSecret;
            })
            .AddFacebook(option =>
            {
                option.AppId = externalsAuthOptions.FacebookAppId;
                option.AppSecret = externalsAuthOptions.FacebookAppSecret;
            })
            .AddGoogle(option =>
            {
                option.ClientId = externalsAuthOptions.GoogleClientKey;
                option.ClientSecret = externalsAuthOptions.GoogleClientSecret;
            });

        services.AddAuthorization(option =>
        {
            option.AddPolicy(Roles.Admin.ToString(),
                policy => policy.RequireClaim(Roles.Admin.ToString(), "Admin"));
            option.AddPolicy(Roles.Crafter.ToString(),
                policy => policy.RequireClaim(Roles.Crafter.ToString(), "Crafter"));
            option.AddPolicy(Roles.AuthenticatedUser.ToString(),
                policy => policy.RequireClaim(Roles.AuthenticatedUser.ToString(), "User"));
        });

        return services;
    }

    public static IServiceCollection IdentityRegistrar(this IServiceCollection services)
    {
        services.AddIdentity<User, UserRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddRoleManager<RoleManager<UserRole>>()
            .AddDefaultTokenProviders();
        return services;
    }

    public static IServiceCollection CorsRegistrar(this IServiceCollection services)
    {
        services.AddCors(option =>
            option.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            )
        );
        return services;
    }
}