using Bazar.Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bazar.Api.Services.Contracts;

public interface IAddressService
{
    Task<Address> Add(Address address);
    Task<Address> Edit(Address address);
    Task<IEnumerable<Address>> GetAll();
    Task<IEnumerable<Address>> Get(Guid addressId);
    Task<IEnumerable<Address>> GetUserAddress(Guid userId);
    Task<IEnumerable<Address>> DeleteUserAddress(Guid userId);
    Address Remove(Address address);
    Address RemoveAll();
}