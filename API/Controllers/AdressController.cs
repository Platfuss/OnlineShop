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
        public async Task<AddressModel> GetAdress(int id)
        {
            return await _addressService.GetAddress(id);
        }

        [HttpPut("InsertAddress")]
        public async Task InsertAdress(AddressModel model)
        {
            await _addressService.InsertAddress(model);
        }

        [HttpPatch("UpdateAddress")]
        public async Task UpdateAdress(AddressModel model)
        {
            await _addressService.UpdateAddress(model);
        }

        [HttpDelete("DeleteAddress/{id}")]
        public async Task DeleteAdress(int id)
        {
            await _addressService.DeleteAddress(id);
        }
    }
}
