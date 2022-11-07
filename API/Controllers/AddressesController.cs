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

    [HttpGet("{id}")]
    public async Task<Address> GetAddress(int id)
    {
        return await _addressService.GetAddressAsync(id);
    }

    [HttpPatch("update")]
    public async Task<Address> UpdateAddress(Address model)
    {
        return await _addressService.UpdateAddressAsync(model);
    }
}
