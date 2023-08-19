using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class UserController : BaseController<UserController, IUserService>
{
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
        var user = await Service.Get(id);

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

        Logger.Log(LogLevel.Trace, userId);

        var user = await Service.Get(Guid.Parse((ReadOnlySpan<char>)userId));
        return Ok(user);
    }
}