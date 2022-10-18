using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService) => _addressService = addressService;

        [HttpGet("GetAddress/{id}")]
        public async Task<AddressModel> GetAddress(int id)
        {
            return await _addressService.GetAddress(id);
        }

        [HttpPost("InsertAddress")]
        public async Task<AddressModel> InsertAddress(AddressModel model)
        {
            return await _addressService.InsertAddress(model);
        }

        [HttpPatch("UpdateAddress")]
        public async Task<AddressModel> UpdateAddress(AddressModel model)
        {
            return await _addressService.UpdateAddress(model);
        }

        [HttpDelete("DeleteAddress/{id}")]
        public async Task DeleteAddress(int id)
        {
            await _addressService.DeleteAddress(id);
        }
    }
}
