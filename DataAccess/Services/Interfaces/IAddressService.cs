using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;

namespace DataAccess.Services.Interfaces;

public interface IAddressService
{
    Task<Address> AddAddressAsync(AddressRequest request);
    Task<bool> DeleteAddressAsync(int addressId);
    Task<List<Address>> GetAddressesAsync();
    Task<Address> UpdateAddressAsync(Address model);
}