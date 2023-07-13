using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMapper _mapper;

    public PostController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{postId}", Name = "Get")]
    public Task<IActionResult> Get(string postId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> Create([FromBody] string value)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{postId}")]
    public Task<IActionResult> Update(string postId, [FromBody] string value)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{postId}")]
    public Task<IActionResult> Delete(string postId)
    {
        throw new NotImplementedException();
    }
}