using System.Net;
using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<T, TService> : ControllerBase
    where T : BaseController<T, TService>
    where TService : notnull
{
    private IMapper? mapperrr;
    private ILogger<T>? _logger;
    private TService? _service;

    protected Guid UserId => new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                                      throw new AggregateException("there is no UserId"));

    protected TService Service
        => _service ??= HttpContext.RequestServices.GetRequiredService<TService>();

    protected ILogger Logger
        => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

    protected bool UserIsAuthenticated
        => HttpContext.User.Identity is { IsAuthenticated: true };

    protected IMapper Mapper
        => mapperrr ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
}