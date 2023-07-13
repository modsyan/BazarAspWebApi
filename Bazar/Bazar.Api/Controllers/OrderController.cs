using AutoMapper;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMapper _mapper;

    public OrderController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost("{cartId}")]
    public Task<IActionResult> Create(string cartId)
    {
        // TODO: DELETE THE USER CART AFTER CREATING THE ORDER
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        //TODO RETURN ALL USER ORDERS
        throw new NotImplementedException();
    }

    [HttpGet("{orderId}")]
    public Task<IActionResult> Get(string orderId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{orderId}")]
    public Task<IActionResult> Update(string orderId, [FromBody] UpdateOrderRequest dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{orderId}")]
    public Task<IActionResult> Cancel(string orderId)
    {
        throw new NotImplementedException();
    }
}