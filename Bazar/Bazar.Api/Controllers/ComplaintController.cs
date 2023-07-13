using AutoMapper;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComplaintController : ControllerBase
{
    private readonly IMapper _mapper;

    public ComplaintController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public Task<IActionResult> Add([FromBody] CreateComplaintRequestDto dto)
    {
        throw new NotImplementedException();
    }

    //ADMIN ONLY 

    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{complaintId}")]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Get(string complaintId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{complaintId}")]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Remove(string complaintId)
    {
        throw new NotImplementedException();
    }
}