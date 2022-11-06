using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IUserService
{
    Task<Customer> GetCustomerAsync();
    string GetEmail();
}