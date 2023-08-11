using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Bazar.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/users/me/[controller]/")]
public class BlacklistController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<BlacklistController> _logger;
    private readonly IBlacklistService _blacklistService;

    public BlacklistController(IMapper mapper, IBlacklistService blacklistService, ILogger<BlacklistController> logger)
    {
        _mapper = mapper;
        _blacklistService = blacklistService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var usersBlocked = await _blacklistService.GetList(userId);

        return usersBlocked is null
            ? NotFound(new { success = false, message = "there is no Blocked users" })
            : Ok(new { success = true, users = _mapper.Map<GetUserMinimalResponseDto>(usersBlocked) });
    }

    [HttpPost("{targetId:guid}")]
    public async Task<IActionResult> Block(Guid targetId)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var usersBlocked = await _blacklistService.Include(userId, targetId);

        _logger.Log(LogLevel.Debug, usersBlocked.ToString());

        return usersBlocked is null
            ? NotFound(new { success = false, message = "Target id to get blocked not found" })
            : Ok(new { success = true, users = _mapper.Map<GetUserMinimalResponseDto>(usersBlocked) });
    }

    [HttpDelete("{targetId:guid}")]
    public async Task<IActionResult> UnBlock(Guid targetId)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var usersBlocked = await _blacklistService.Exclude(userId, targetId);

        return usersBlocked is null
            ? NotFound(new { success = false, message = "Target id to get blocked not found" })
            : Ok(new { success = true, users = _mapper.Map<GetUserMinimalResponseDto>(usersBlocked) });
    }
}