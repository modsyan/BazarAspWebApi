using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class AddressService : IAddressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddressService> _logger;

    public AddressService(IUnitOfWork unitOfWork, ILogger<AddressService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Address> Add(Address address)
    {
        var createdAddress = await _unitOfWork.Addresses.CreateAsync(address);
        await _unitOfWork.CompleteAsync();
        return createdAddress;
    }

    public async Task<Address> Edit(Guid addressId, Address address)
    {
        var existingAddress = await _unitOfWork.Addresses.GetAsync(addressId) ??
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

        await _unitOfWork.CompleteAsync();
        return existingAddress;
    }

    public async Task<Address?> GetAddress(Guid addressId)
    {
        return await _unitOfWork.Addresses.GetAsync(addressId);
    }

    public async Task<IEnumerable<Address>> GetUserAddress(Guid userId)
    {
        return await _unitOfWork.Addresses.FindAllAsync(address =>
            address.User != null && address.User.Id == userId);
    }

    public async Task<IEnumerable<Address>> DeleteUserAddresses(Guid userId)
    {
        var deletedAddresses = (await _unitOfWork.Addresses.FindAllAsync(a => a.User.Id == userId)).ToList();
        _unitOfWork.Addresses.DeleteRange(deletedAddresses);
        await _unitOfWork.CompleteAsync();
        return deletedAddresses;
    }

    public bool Delete(Guid addressId)
    {
        if (!_unitOfWork.Addresses.Delete(addressId)) return false;
        _unitOfWork.CompleteAsync();
        return true;
    }
}