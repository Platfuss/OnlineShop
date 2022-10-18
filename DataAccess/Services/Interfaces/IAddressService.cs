using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IAddressService
    {
        Task DeleteAddress(int id);
        Task<AddressModel> GetAddress(int id);
        Task<AddressModel> InsertAddress(AddressModel model);

        Task<AddressModel> UpdateAddress(AddressModel model);
    }
}