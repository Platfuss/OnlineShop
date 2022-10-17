using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public async Task<CustomerModel> GetCustomer(int id)
        {
            return await _customers.GetCustomer(id);
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            return await _customers.GetCustomersAll();
        }

        [HttpPost("InsertCustomer")]
        public async Task InsertCustomer(CustomerModel model)
        {
           await _customers.InsertCustomer(model);
        }

        [HttpPatch("UpdateCustomer")]
        public async Task UpdateCustomer(CustomerModel model)
        {
            await _customers.UpdateCustomer(model);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task DeleteCustomer(int id)
        {
            await _customers.DeleteCustomer(id);
        }
    }
}
