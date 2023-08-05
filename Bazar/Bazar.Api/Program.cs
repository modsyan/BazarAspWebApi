using System.Threading.RateLimiting;
using Bazar.Api.Extensions;
using Bazar.Api.Middlewares;
using Bazar.Api.Services;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;
using Bazar.EF.Repositories;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.DbContextRegistrar(configuration: builder.Configuration);
builder.Services.CorsRegistrar();
builder.Services.IdentityRegistrar();
builder.Services.ConfigurationServicesRegistrar(configuration: builder.Configuration);
builder.Services.TransitServicesRegistrar();
builder.Services.ScopedServicesRegistrar();
builder.Services.SingletonServicesRegistrar();
builder.Services.AuthenticationRegistrar(configuration: builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 4;
        options.Window = TimeSpan.FromSeconds(12);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();