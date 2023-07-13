using AutoMapper;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("/api/[]")]
public class AddressController : ControllerBase
{
    
    private readonly IMapper _mapper;

    public AddressController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("/")]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("/{id}")]
    public Task<IActionResult> Get(string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("/")]
    public Task<IActionResult> Create([FromBody] CreateAddressesRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("/{id}")]
    public Task<IActionResult> Update(string id, [FromBody] UpdateAddressRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("/{id}")]
    public Task<IActionResult> Delete(string id)
    {
        throw new NotImplementedException();
    }
}