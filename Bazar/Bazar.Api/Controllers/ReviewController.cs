using AutoMapper;
using Bazar.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Bazar.Api.Controllers;

[Authorize]
[Route("api/products/{productId}/[controller]")]
public class ReviewController : BaseController<ReviewController, IMapper>
{
    [HttpGet]
    public Task<IActionResult> Get(string productId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> Create(string productId)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{reviewId}")]
    public Task<IActionResult> Update(string productId, string reviewId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{reviewId}")]
    public Task<IActionResult> Remove(string productId, string reviewId)
    {
        throw new NotImplementedException();
    }
}