using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomersService _customers;

    public CustomersController(ICustomersService customers)
    {
        _customers = customers;
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetCustomer()
    {
        return await _customers.GetCustomerAsync();
    }

    [HttpPatch("update")]
    public async Task<Customer> UpdateCustomer(Customer model)
    {
        return await _customers.UpdateCustomerAsync(model);
    }
}
