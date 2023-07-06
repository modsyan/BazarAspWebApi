using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController
{
    [HttpPost]
    public Task<IActionResult> Create(string cartId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> Remove(string orderId)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<IActionResult> EditOrder()
    {
        throw new NotImplementedException();
    }
}