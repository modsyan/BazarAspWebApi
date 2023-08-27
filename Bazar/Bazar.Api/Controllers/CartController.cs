using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class CartController : BaseController<CartController, ICartService>
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{cartId:guid}")]
    public Task<IActionResult> Delete(Guid cartId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("items/{itemId:guid}")]
    public Task<IActionResult> GetItem(Guid itemId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("items")]
    public Task<IActionResult> AddItem(AddItemCartRequestDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpPut("items/{itemId:guid}")]
    public Task<IActionResult> UpdateItem(Guid itemId, UpdateItemCartRequestDto dto)
    {
        // TODO: Update the quantity or other details of a cart item.
        throw new NotImplementedException();
    }

    [HttpDelete("items/{itemId:guid}")]
    public Task<IActionResult> RemoveItem(Guid itemId)
    {
        throw new NotImplementedException();
    }
}