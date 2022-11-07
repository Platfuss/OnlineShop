using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IAddressService
{
    Task<Address> GetAddressAsync(int id);
    Task<Address> UpdateAddressAsync(Address model);
}