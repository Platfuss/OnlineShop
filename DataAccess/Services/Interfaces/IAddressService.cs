using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IAddressService
{
    Task DeleteAddressAsync(int id);
    Task<Address> GetAddressAsync(int id);
    Task<Address> InsertAddressAsync(Address model);
    Task<Address> UpdateAddressAsync(Address model);
}