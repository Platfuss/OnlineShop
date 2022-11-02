using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface ICustomersService
    {
        Task DeleteCustomer(int id);
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomersAll();
        Task<Customer> InsertCustomer(Customer model);
        Task<Customer> UpdateCustomer(Customer model);
    }
}