using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface ICustomersService
{
    Task<Customer> GetCustomerAsync();
    Task<Customer> UpdateCustomerAsync(Customer model);
}