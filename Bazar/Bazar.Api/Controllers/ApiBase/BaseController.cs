using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers.ApiBase;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<TController, TService> : ControllerBase
    where TController : BaseController<TController, TService>
    where TService : notnull
{
    private IMapper? _mapper;
    private ILogger<TController>? _logger;
    private TService? _service;

    protected Guid UserId => new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                                      throw new AggregateException("there is no UserId"));

    protected TService Service
        => _service ??= HttpContext.RequestServices.GetRequiredService<TService>();

    protected ILogger Logger
        => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<TController>>();

    protected bool UserIsAuthenticated
        => HttpContext.User.Identity is { IsAuthenticated: true };

    protected IMapper Mapper
        => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
}