using DataAccess.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomersService _customers;

    public CustomerController(ICustomersService customers)
    {
        _customers = customers;
    }

    [HttpGet("GetCustomer/{id}")]
    public async Task<Customer> GetCustomer(int id)
    {
        return await _customers.GetCustomerAsync(id);
    }

    [HttpGet("GetAllCustomers")]
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await _customers.GetCustomersAllAsync();
    }

    [HttpPost("InsertCustomer")]
    public async Task<Customer> InsertCustomer(Customer model)
    {
        return await _customers.InsertCustomerAsync(model);
    }

    [HttpPatch("UpdateCustomer")]
    public async Task<Customer> UpdateCustomer(Customer model)
    {
        return await _customers.UpdateCustomerAsync(model);
    }

    [HttpDelete("DeleteCustomer/{id}")]
    public async Task DeleteCustomer(int id)
    {
        await _customers.DeleteCustomerAsync(id);
    }
}
