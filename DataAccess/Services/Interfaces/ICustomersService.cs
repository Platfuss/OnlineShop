using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface ICustomersService
{
    Task DeleteCustomerAsync(int id);
    Task<Customer> GetCustomerAsync(int id);
    Task<IEnumerable<Customer>> GetCustomersAllAsync();
    Task<Customer> InsertCustomerAsync(Customer model);
    Task<Customer> UpdateCustomerAsync(Customer model);
}