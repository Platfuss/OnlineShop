using DataAccess.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService) => _addressService = addressService;

    [HttpGet("GetAddress/{id}")]
    public async Task<Address> GetAddress(int id)
    {
        return await _addressService.GetAddressAsync(id);
    }

    [HttpPost("InsertAddress")]
    public async Task<Address> InsertAddress(Address model)
    {
        return await _addressService.InsertAddressAsync(model);
    }

    [HttpPatch("UpdateAddress")]
    public async Task<Address> UpdateAddress(Address model)
    {
        return await _addressService.UpdateAddressAsync(model);
    }

    [HttpDelete("DeleteAddress/{id}")]
    public async Task DeleteAddress(int id)
    {
        await _addressService.DeleteAddressAsync(id);
    }
}
