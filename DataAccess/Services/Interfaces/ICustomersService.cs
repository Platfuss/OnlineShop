using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;

namespace DataAccess.Services.Interfaces;

public interface ICustomersService
{
    Task<CustomerBasicInfo> GetCustomerAsync();
    Task<Customer> UpdateCustomerAsync(CustomerBasicInfo model);
}