using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController
{
    [HttpGet]
    public Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public Task<IActionResult> GetItem(string itemId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> AddItem()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    public Task<IActionResult> RemoveItem(string itemId)
    {
        throw new NotImplementedException();
    }
    
    // Update the quantity or other details of a cart item.
    [HttpPut]
    public Task<IActionResult> UpdateItem(string itemId, CartItem cartItem)
    {
        throw new NotImplementedException();
    }
}
