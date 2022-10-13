
using DataAccess.Data.Interfaces;
using DataAccess.DatabaseAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAddressData _address;

        public AdressController(IDatabase db)
        {
            _address = new AddressData(db);
        }

        [Route("api/[controller]/GetAddress")]
        [HttpGet]
        public async Task<AddressModel> GetAdress(int id)
        {
            return await _address.GetAddress(id);
        }

        [Route("api/[controller]/InsertAddress")]
        [HttpPut]
        public async Task InsertAdress(AddressModel model)
        {
            await _address.InsertAddress(model);
        }

        [Route("api/[controller]/UpdateAddress")]
        [HttpPatch]
        public async Task UpdateAdress(AddressModel model)
        {
            await _address.UpdateAddress(model);
        }

        [Route("api/[controller]/DeleteAddress")]
        [HttpDelete]
        public async Task DeleteAdress(int id)
        {
            await _address.DeleteAddress(id);
        }
    }
}
