using AutoMapper;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Route("/api/categories")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    
    private readonly IMapper _mapper;

    public CategoryController(IMapper mapper)
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
    public Task<IActionResult> Create(CreateCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("/{id}")]
    public Task<IActionResult> Update(string id, UpdateCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    public Task<IActionResult> Delete(CreateCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    // Adding and removing Products From Categories
    
    [HttpPost("/{categoryId}/products/{productId}")]
    public Task<IActionResult> AddProduct(string categoryId, string productId)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("/{categoryId}/products/{productId}")]
    public Task<IActionResult> RemoveProduct(string categoryId, string productId)
    {
        throw new NotImplementedException();
    }
}