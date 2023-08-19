using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[Route("api/users/")]
public class FollowerController : BaseController<FollowerController, IFollowerService>
{
    [HttpGet("{userId}/Followers")]
    public Task<IActionResult> Followers(string userId)
    {
        // Only Read ?? The Users Who Fills the Follows me
        throw new NotImplementedException();
    }

    [HttpGet("{userId}/Following")]
    public Task<IActionResult> GetUserFollowing(string userId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("me/Followers")]
    public Task<IActionResult> GetUserFollowers()
    {
        // Only Read ?? The Users Who Fills the Follows me
        throw new NotImplementedException();
    }

    [HttpGet("me/Following")]
    public Task<IActionResult> GetMyFollowing()
    {
        throw new NotImplementedException();
    }

    [HttpPost("me/Follow/{userId}")]
    public Task<IActionResult> Follow(string userId)
    {
        // Add People To Follow
        // Todo Me Follow them
        throw new NotImplementedException();
    }

    [HttpDelete("me/Follow/{userId}")]
    public Task<IActionResult> UnFollow(string userId)
    {
        throw new NotImplementedException();
    }
}