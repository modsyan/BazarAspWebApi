using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bazar.Api.Services.Contracts;

public interface IAddressService
{
    Task<Address> Add(Address address);
    Task<Address> Edit(Guid addressId, Address address);
    Task<Address?> GetAddress(Guid addressId);
    Task<IEnumerable<Address>> GetUserAddress(Guid userId);
    Task<IEnumerable<Address>> DeleteUserAddresses(Guid userId);
    bool Delete(Guid addressId);
}