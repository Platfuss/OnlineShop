using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface ICustomersService
    {
        Task DeleteCustomer(int id);
        Task<CustomerModel> GetCustomer(int id);
        Task<IEnumerable<CustomerModel>> GetCustomersAll();
        Task<CustomerModel> InsertCustomer(CustomerModel model);
        Task<CustomerModel> UpdateCustomer(CustomerModel model);
    }
}