using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/{resourceType}/{resourceId}/[controller]")]
public class ReactController : ControllerBase
{
    private readonly IMapper _mapper;

    public ReactController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
        {
            throw new NotImplementedException();
        }
        else if (resourceType == "Comments")
        {
            throw new NotImplementedException();
        }
        else
        {
            return BadRequest("Invalid resource type");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
        {
            throw new NotImplementedException();
        }
        else if (resourceType == "Comments")
        {
            throw new NotImplementedException();
        }
        else
        {
            return BadRequest("Invalid resource type");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
        {
            throw new NotImplementedException();
        }
        else if (resourceType == "Comments")
        {
            throw new NotImplementedException();
        }
        else
        {
            return BadRequest("Invalid resource type");
        }
    }
    

    [HttpDelete]
    public async Task<IActionResult> Remove(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
        {
            throw new NotImplementedException();
        }
        else if (resourceType == "Comments")
        {
            throw new NotImplementedException();
        }
        else
        {
            return BadRequest("Invalid resource type");
        }
    }
}