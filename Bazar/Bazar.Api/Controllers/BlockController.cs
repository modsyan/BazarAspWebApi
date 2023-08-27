using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class BlockController : BaseController<BlockController, IBlockService>
{
    [HttpGet("blocked")]
    public async Task<IActionResult> Get()
    {
        var blockedUsers = (await Service.GetBlocked(UserId)).Select(block =>
            Mapper.Map<UserResponseDto>(block.BlockedUser)).ToList();

        return Ok(new { success = true, users = blockedUsers, });
    }

    [HttpPost("{targetId:guid}")]
    public async Task<IActionResult> Block(Guid targetId)
    {
        var blockUserState = (await Service.BlockUserAsync(UserId, targetId));

        return !blockUserState
            ? NotFound(new { success = false, message = "User is Already Blocked or not exist." })
            : Ok(new { success = true, });
    }

    [HttpDelete("{targetId:guid}")]
    public async Task<IActionResult> UnBlock(Guid targetId)
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var usersBlocked = await Service.UnblockUserAsync(userId, targetId);

        return !usersBlocked
            ? NotFound(new { success = false, message = "Target id to get blocked not found" })
            : Ok(new { success = true, });
    }
}