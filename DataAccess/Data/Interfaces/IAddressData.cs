using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IAddressData
    {
        Task DeleteAddress(int id);
        Task<AddressModel> GetAddress(int id);
        Task InsertAddress(AddressModel model);

        Task UpdateAddress(AddressModel model);
    }
}