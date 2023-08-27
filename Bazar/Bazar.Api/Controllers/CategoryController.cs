using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class CategoryController : BaseController<CategoryController, ICategoryService>
{
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
    public Task<IActionResult> Create(CreateEditCategoryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:guid}")]
    public Task<IActionResult> Update(Guid id, CreateEditCategoryRequestDto dto)
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