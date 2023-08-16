using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;

namespace Bazar.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/users/me/[controller]/")]
public class BlockController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<BlockController> _logger;
    private readonly IBlockService _blockService;

    public BlockController(IMapper mapper, IBlockService blockService, ILogger<BlockController> logger)
    {
        _mapper = mapper;
        _blockService = blockService;
        _logger = logger;
    }

    [HttpGet("blocked")]
    public async Task<IActionResult> Get()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);

        var blockedUsers = (await _blockService.GetBlocked(userId)).Select(block =>
            _mapper.Map<GetUserMinimalResponseDto>(block.BlockedUser)).ToList();

        return blockedUsers.IsNullOrEmpty()
            ? NotFound(new { success = false, message = "there is no Blocked users" })
            : Ok(new
            {
                success = true, users = blockedUsers,
            });
    }

    [HttpPost("{targetId:guid}")]
    public async Task<IActionResult> Block(Guid targetId)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var blockUserState = (await _blockService.BlockUserAsync(userId, targetId));


        return !blockUserState
            ? NotFound(new { success = false, message = "User is Already Blocked or not exist." })
            : Ok(new
            {
                success = true,
                // users = (await _blockService.GetBlocked(userId)).Select(block =>
                //     _mapper.Map<GetUserMinimalResponseDto>(block.BlockedUser)).ToList()
            });
    }

    [HttpDelete("{targetId:guid}")]
    public async Task<IActionResult> UnBlock(Guid targetId)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var usersBlocked = await _blockService.UnblockUserAsync(userId, targetId);

        return !usersBlocked
            ? NotFound(new { success = false, message = "Target id to get blocked not found" })
            : Ok(new
            {
                success = true,
                // users = usersBlocked.Select(user => _mapper.Map<GetUserMinimalResponseDto>(usersBlocked))
            });
    }
}