using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;

namespace Bazar.Api.Services;

public class AddressService : IAddressService
{
    public async Task<Address> Add(Address address)
    {
        throw new NotImplementedException();
    }

    public async Task<Address> Edit(Address address)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Address>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Address>> Get(Guid addressId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Address>> GetUserAddress(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Address>> DeleteUserAddress(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Address Remove(Address address)
    {
        throw new NotImplementedException();
    }

    public Address RemoveAll()
    {
        throw new NotImplementedException();
    }
}