using Bazar.Api.Middlewares;
using Bazar.Api.Startup;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();
app.ConfigureEndpoints();

app.Run();