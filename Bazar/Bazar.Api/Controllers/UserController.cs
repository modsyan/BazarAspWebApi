using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IMapper mapper, IUserRepository userRepository, IUserService userService,
        ILogger<UserController> logger)
    {
        _mapper = mapper;
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        // todo Return All The Users
        // Add To Schema if the User is FollowMe Or Not To SendBack
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.Get(id);

        return Ok(new
        {
            success = true,
            user
        });
    }

    [HttpGet("Me")]
    public async Task<IActionResult> GetMe()
    {
        var userId = User.Claims.FirstOrDefault(user => user.Type == "Id")?.Value!;

        _logger.Log(LogLevel.Trace, userId);

        var user = await _userService.Get(Guid.Parse((ReadOnlySpan<char>)userId));
        return Ok(user);
    }
}