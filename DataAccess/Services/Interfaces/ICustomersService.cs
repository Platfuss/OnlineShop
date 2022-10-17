using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface ICustomersService
    {
        Task DeleteCustomer(int id);
        Task<CustomerModel> GetCustomer(int id);
        Task<IEnumerable<CustomerModel>> GetCustomersAll();
        Task InsertCustomer(CustomerModel model);
        Task UpdateCustomer(CustomerModel model);
    }
}