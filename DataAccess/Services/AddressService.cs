using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class AddressService : IAddressService
    {
        private readonly IDatabase _db;

        public AddressService(IDatabase db)
        {
            _db = db;
        }

        public async Task<AddressModel> GetAddress(int id)
        {
            var results = await _db.ExecuteProcedure<AddressModel, dynamic>("sp_Address_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<AddressModel> InsertAddress(AddressModel model)
        {
            var results = await _db.ExecuteProcedure<AddressModel, AddressModel>("sp_Address_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<AddressModel> UpdateAddress(AddressModel model)
        {
            var results = await _db.ExecuteProcedure<AddressModel, AddressModel>("sp_Address_Update", model);
            return results.FirstOrDefault();
        }

        public Task DeleteAddress(int id) =>
             _db.ExecuteProcedure("sp_Address_Delete", new { Id = id });
    }
}
