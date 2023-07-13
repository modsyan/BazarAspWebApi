using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/users/me/[controller]")]
public class SettingsController : ControllerBase
{
    
    private readonly IMapper _mapper;

    public SettingsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpPost("reset")]
    public Task<IActionResult> Reset()
    {
        throw new NotImplementedException();
    }
}