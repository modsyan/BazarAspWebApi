using System.Security.Claims;
using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
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
// public class AddressController : BaseController<AddressController, IAddressService>
public class AddressController : CrudController<
    AddressController,
    IAddressService,
    Address,
    AddressDto,
    AddressDto
>
{
    private readonly IUserService _userService;

    public AddressController(IUserService userService)
    {
        _userService = userService;
    }

    #region old_controller

    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     var addresses = await Service.GetAll(UserId);
    //
    //     var addressesResponse = addresses
    //         .Select(a =>
    //         {
    //             var adr = Mapper.Map<AddressDto>(a);
    //             adr.UserId = UserId;
    //             return adr;
    //         });
    //
    //     return Ok(new { status = true, addresses = addressesResponse });
    // }
    //
    // [HttpGet("{addressId:guid}")]
    // public async Task<IActionResult> Get(Guid addressId)
    // {
    //     var address = await Service.Get(addressId);
    //     return address is null
    //         ? NotFound(new
    //         {
    //             success = false,
    //             message = $"Address with that id {addressId} not found",
    //         })
    //         : Ok(new
    //         {
    //             status = true,
    //             address = Mapper.Map<AddressDto>(address)
    //         });
    // }
    //
    // // [RequireClaim()]
    // [HttpGet("~/api/users/{userId:guid}/address")]
    // // [Authorize(Roles = Roles.Admin)]
    // public async Task<IActionResult> GetUserAddresses(Guid userId)
    // {
    //     var addresses = (await Service.GetAll(userId)).ToList();
    //
    //     if (addresses.IsNullOrEmpty())
    //         return NotFound(new { status = false, message = "there is no addresses to get" });
    //
    //     var addressesResponse = addresses.Select(a =>
    //     {
    //         var tmp = Mapper.Map<AddressDto>(a);
    //         // TODO:needed to fix from mapping profile
    //         tmp.UserId = userId;
    //         return tmp;
    //     });
    //
    //     return Ok(new { status = true, addresses = addressesResponse });
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> Create([FromBody] AddressDto dto)
    // {
    //     var address = Mapper.Map<Address>(dto);
    //     // mappedAddress.User = await _userService.Get(UserId);
    //     var createdAddress = await Service.Add(UserId, address);
    //
    //     return CreatedAtAction(
    //         "Get", new { id = createdAddress.Id, },
    //         new { success = true, address = Mapper.Map<AddressDto>(createdAddress) });
    // }
    //
    // [HttpPatch("{addressId:guid}")]
    // public async Task<IActionResult> Update([FromRoute] Guid addressId, [FromBody] AddressDto dto)
    // {
    //     var address = Mapper.Map<Address>(dto);
    //
    //     var updateAddress = await Service.Edit(addressId, address);
    //
    //     return Ok(new
    //     {
    //         success = true,
    //         address = Mapper.Map<AddressDto>(updateAddress)
    //     });
    // }
    //
    // [HttpDelete("{addressId:guid}")]
    // public IActionResult Delete(Guid addressId)
    // {
    //     return !Service.Delete(addressId)
    //         ? NotFound(new
    //         {
    //             sucess = false,
    //             message = "there is no Address with that id",
    //         })
    //         : Ok(new
    //         {
    //             success = true,
    //             message = "Address has been deleted successfully."
    //         });
    // }

    #endregion

    // [HttpDelete("~/api/users/{userId:guid}/address")]
    // public async Task<IActionResult> DeleteAllUserAddresses(Guid userId)
    // {
    //     // Todo: throw notfound and badRequest exceptions from services direct after handling Global exception Middleware 
    //     var deletedUserAddresses = (await Service.DeleteAll(userId)).ToList();
    //
    //     return deletedUserAddresses.IsNullOrEmpty()
    //         ? NotFound(new
    //         {
    //             success = false,
    //             message = "There is no addresses to delete"
    //         })
    //         : Ok(new
    //         {
    //             success = true,
    //             deletedAddresses = deletedUserAddresses
    //         });
    // }


    // [HttpDelete]
    // public async Task<IActionResult> DeleteMyAddresses()
    // {
    //     var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    //
    //     var deletedUserAddresses = (await Service.DeleteAll(userId)).ToList();
    //
    //     return deletedUserAddresses.IsNullOrEmpty()
    //         ? NotFound(new
    //         {
    //             success = false,
    //             message = "There is no addresses to delete"
    //         })
    //         : Ok(new
    //         {
    //             success = true,
    //             deletedAddresses = deletedUserAddresses
    //         });
    // }
}