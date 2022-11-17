using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService) => _addressService = addressService;

    [HttpPatch("update")]
    public async Task<Address> UpdateAddress(Address model)
    {
        return await _addressService.UpdateAddressAsync(model);
    }

    [HttpPost("add")]
    public async Task<Address> AddAddress(AddressRequest request)
    {
        return await _addressService.AddAddressAsync(request);
    }

    [HttpGet("all")]
    public async Task<List<Address>> GetAddresses()
    {
        return await _addressService.GetAddressesAsync();
    }

    [HttpDelete("{addressId}")]
    public async Task<bool> DeleteAddress(int addressId)
    {
        return await _addressService.DeleteAddressAsync(addressId);
    }
}
