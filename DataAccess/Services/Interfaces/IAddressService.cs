using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IAddressService
{
    Task DeleteAddress(int id);
    Task<Address> GetAddress(int id);
    Task<Address> InsertAddress(Address model);

    Task<Address> UpdateAddress(Address model);
}