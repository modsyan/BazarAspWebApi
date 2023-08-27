using System.Xml;
using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[Route("api/[controller]/items/")]
public class WishlistController : BaseController<WishlistController, IWishlistService>
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{productId:guid}")]
    public Task<IActionResult> Create(Guid productId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{productId:guid}")]
    public Task<IActionResult> Remove(Guid productId)
    {
        throw new NotImplementedException();
    }
}