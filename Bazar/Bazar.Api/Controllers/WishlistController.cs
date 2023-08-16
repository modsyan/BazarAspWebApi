using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/items/")]
public class WishlistController : ControllerBase
{
    private readonly IMapper _mapper;

    public WishlistController(IMapper mapper)
    {
        _mapper = mapper;
    }

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