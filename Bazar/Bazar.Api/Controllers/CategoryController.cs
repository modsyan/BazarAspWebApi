using AutoMapper;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IMapper _mapper;

    public CategoryController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> Create(CreateCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:guid}")]
    public Task<IActionResult> Update(Guid id, UpdateCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    // Adding and removing Products From Categories
    [HttpPost("{categoryId:guid}/products/{productId:guid}")]
    public Task<IActionResult> AddProduct(Guid categoryId, Guid productId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{categoryId:guid}/products/{productId:guid}")]
    public Task<IActionResult> RemoveProduct(Guid categoryId, Guid productId)
    {
        throw new NotImplementedException();
    }
}