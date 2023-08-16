using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAddressService _addressService;
    private readonly IUserService _userService;

    public AddressController(IMapper mapper, IAddressService addressService, IUserService userService)
    {
        _mapper = mapper;
        _addressService = addressService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                              throw new ArgumentException("there is no Id, login again."));

        var addresses = (await _addressService.GetUserAddress(userId)).ToList();
        // var addressesResponse = _mapper.Map<IEnumerable<AddressDto>>(addresses);
        if (addresses.IsNullOrEmpty())
            return NotFound(new { status = false, message = "there is no addresses to get" });

        var addressesResponse = addresses
            .Select(a =>
            {
                var adr = _mapper.Map<AddressDto>(a);
                adr.UserId = userId;
                return adr;
            });

        return Ok(new { status = true, addresses = addressesResponse });
    }

    [HttpGet("{addressId:guid}")]
    public async Task<IActionResult> Get(Guid addressId)
    {
        var address = await _addressService.GetAddress(addressId);
        return address is null
            ? NotFound(new
            {
                success = false,
                message = $"Address with that id {addressId} not found",
            })
            : Ok(new
            {
                status = true,
                address = _mapper.Map<AddressDto>(address)
            });
    }

    // [RequireClaim()]
    [HttpGet("~/api/users/{userId:guid}/address")]
    // [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetUserAddresses(Guid userId)
    {
        var addresses = (await _addressService.GetUserAddress(userId)).ToList();

        if (addresses.IsNullOrEmpty())
            return NotFound(new { status = false, message = "there is no addresses to get" });

        var addressesResponse = addresses.Select(a =>
        {
            var tmp = _mapper.Map<AddressDto>(a);
            // TODO:needed to fix from mapping profile
            tmp.UserId = userId;
            return tmp;
        });

        return Ok(new { status = true, addresses = addressesResponse });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddressDto dto)
    {
        var mappedAddress = _mapper.Map<Address>(dto);

        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                              throw new AggregateException("userId not found, login again."));

        mappedAddress.User = await _userService.Get(userId) ??
                             throw new AggregateException("user not found, login again.");

        var createdAddress = await _addressService.Add(mappedAddress);

        return CreatedAtAction(
            "Get", new { id = createdAddress.Id, },
            new { success = true, address = _mapper.Map<AddressDto>(createdAddress) });
    }

    [HttpPatch("{addressId:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid addressId, [FromBody] AddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);

        var updateAddress = await _addressService.Edit(addressId, address);

        return Ok(new
        {
            success = true,
            address = _mapper.Map<AddressDto>(updateAddress)
        });
    }

    [HttpDelete("{addressId:guid}")]
    public IActionResult Delete(Guid addressId)
    {
        return !_addressService.Delete(addressId)
            ? NotFound(new
            {
                sucess = false,
                message = "there is no Address with that id",
            })
            : Ok(new
            {
                success = true,
                message = "Address has been deleted successfully."
            });
    }

    [HttpDelete("~/api/users/{userId:guid}/address")]
    public async Task<IActionResult> DeleteAllUserAddresses(Guid userId)
    {
        // Todo: throw notfound and badRequest exceptions from services direct after handling Global exception Middleware 
        var deletedUserAddresses = (await _addressService.DeleteUserAddresses(userId)).ToList();

        return deletedUserAddresses.IsNullOrEmpty()
            ? NotFound(new
            {
                success = false,
                message = "There is no addresses to delete"
            })
            : Ok(new
            {
                success = true,
                deletedAddresses = deletedUserAddresses
            });
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteMyAddresses()
    {
        var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var deletedUserAddresses = (await _addressService.DeleteUserAddresses(userId)).ToList();

        return deletedUserAddresses.IsNullOrEmpty()
            ? NotFound(new
            {
                success = false,
                message = "There is no addresses to delete"
            })
            : Ok(new
            {
                success = true,
                deletedAddresses = deletedUserAddresses
            });
    }
}