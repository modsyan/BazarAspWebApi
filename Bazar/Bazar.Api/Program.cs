using Bazar.Api.Helpers;
using Bazar.Api.Middlewares;
using Microsoft.OpenApi.Models;
using Bazar.Api.Services;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        optionsBuilder => optionsBuilder.MigrationsAssembly(
            typeof(ApplicationDbContext).Assembly.FullName
        )
    )
);


builder.Services.AddCors();

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<GlobalExceptionMiddleware>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IFaqService, FaqService>();

// builder.Services.AddIdentity<User, IdentityRole>()
    // .AddRoleManager<RoleManager<UserRole>>()
    // .AddEntityFrameworkStores<ApplicationDbContext>()
    // .AddDefaultTokenProviders();

builder.Services.AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc(name: "v1", info: new OpenApiInfo
    {
        Version = "v1",
        Title = "BazarApi",
        Contact = new OpenApiContact
        {
            Name = "Muhammad Hamdy",
            Email = "modclover7@gamil.com",
        },
        Description =
            "This is the AspNetCore WebApi version of Bazar nodejs Application \n'Reminder => needed to change'",
        TermsOfService = new Uri("https://www.BazarCraftting.com/License"),
        License = new OpenApiLicense
        {
            Name = "Bazar Company Licence Name",
            Url = new Uri("https://www.BazarCraftting.com/"),
        }
    });
    option.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "usage: \"Bearer [TOKEN]\""
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
    cor => cor
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost/")
);

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();