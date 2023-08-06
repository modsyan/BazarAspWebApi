using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly ILogger _logger;

    public UserController(IMapper mapper, IUserRepository userRepository, IUserService userService, ILogger logger)
    {
        _mapper = mapper;
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("/")]
    public Task<IActionResult> Get()
    {
        // todo Return All The Users
        // Add To Schema if the User is FollowMe Or Not To SendBack
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetById(string id)
    {
        //todo: check if the user to get is me
        throw new NotImplementedException();
    }

    [HttpGet("Me")]
    public async Task<IActionResult> GetMe()
    {
        var userId = User.Claims.FirstOrDefault(user => user.Type == "Id")?.Value!;
        
        _logger.Log(LogLevel.Trace, userId);

        var user = await _userService.Get(Guid.Parse((ReadOnlySpan<char>) userId));
        return Ok(user);
    }
}