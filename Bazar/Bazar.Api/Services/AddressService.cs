using Bazar.Api.Services.Contracts;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class AddressService : BaseService, IAddressService
{
    private readonly ILogger<AddressService> _logger;

    public AddressService(IUnitOfWork unitOfWork, ILogger<AddressService> logger): base(unitOfWork)
    {
        _logger = logger;
    }

    public async Task<Address> Add(Address address)
    {
        var createdAddress = await UnitOfWork.Addresses.CreateAsync(address);
        await UnitOfWork.CompleteAsync();
        return createdAddress;
    }

    public async Task<Address> Edit(Guid addressId, Address address)
    {
        var existingAddress = await UnitOfWork.Addresses.GetAsync(addressId) ??
                              throw new ArgumentException("AddressId not found, try again with valid Id");

        // BUG:Cannot modify AddressId or marked as modified
        // PropertiesMapper.UpdateProperties(address, existingAddress);

        // Bad Mapping TODO: change mapping
        existingAddress.Country = address.Country;
        existingAddress.City = address.City;
        existingAddress.StreetAddress = existingAddress.StreetAddress;
        existingAddress.ZipCode = address.ZipCode;
        existingAddress.Latitude = address.Latitude;
        existingAddress.Longitude = address.Longitude;

        await UnitOfWork.CompleteAsync();
        return existingAddress;
    }

    public async Task<Address?> GetAddress(Guid addressId)
    {
        return await UnitOfWork.Addresses.GetAsync(addressId);
    }

    public async Task<IEnumerable<Address>> GetUserAddress(Guid userId)
    {
        return await UnitOfWork.Addresses.FindAllAsync(address =>
            address.User != null && address.User.Id == userId);
    }

    public async Task<IEnumerable<Address>> DeleteUserAddresses(Guid userId)
    {
        var deletedAddresses = (await UnitOfWork.Addresses.FindAllAsync(a => a.User.Id == userId)).ToList();
        UnitOfWork.Addresses.DeleteRange(deletedAddresses);
        await UnitOfWork.CompleteAsync();
        return deletedAddresses;
    }

    public bool Delete(Guid addressId)
    {
        if (!UnitOfWork.Addresses.Delete(addressId)) return false;
        UnitOfWork.CompleteAsync();
        return true;
    }
}