using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/products/{productId}/[controller]")]
public class ReviewController: ControllerBase
{
    private readonly IMapper _mapper;

    public ReviewController(IMapper mapper)
    {
        _mapper = mapper;
    }

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