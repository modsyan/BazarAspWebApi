using AutoMapper;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IMapper _mapper;
    public CartController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("/")]
    public Task<IActionResult> GetCart()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("/{cartId}")]
    public Task<IActionResult> Delete(string cartId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("/items/{itemId}")]
    public Task<IActionResult> GetItem(string itemId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("/items")]
    public Task<IActionResult> AddItem(AddItemCartRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPut("/items/{itemId}")]
    public Task<IActionResult> UpdateItem(string itemId, UpdateItemCartRequestDto dto)
    {
        // TODO: Update the quantity or other details of a cart item.
        throw new NotImplementedException();
    }

    [HttpDelete("/items/{itemId}")]
    public Task<IActionResult> RemoveItem(string itemId)
    {
        throw new NotImplementedException();
    }
}