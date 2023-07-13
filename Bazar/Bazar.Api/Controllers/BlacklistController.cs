using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/[controller]/items")]
public class BlacklistController : ControllerBase
{
    
    private readonly IMapper _mapper;

    public BlacklistController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("{userId}")]
    public Task<IActionResult> Block (string userId)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{userId}")]
    public Task<IActionResult> UnBlock (string userId) {
        throw new NotImplementedException();
    }
}