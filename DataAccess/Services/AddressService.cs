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

        public async Task<Address> GetAddress(int id)
        {
            var results = await _db.ExecuteProcedure<Address, dynamic>("sp_Address_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<Address> InsertAddress(Address model)
        {
            var results = await _db.ExecuteProcedure<Address, Address>("sp_Address_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<Address> UpdateAddress(Address model)
        {
            var results = await _db.ExecuteProcedure<Address, Address>("sp_Address_Update", model);
            return results.FirstOrDefault();
        }

        public Task DeleteAddress(int id) =>
             _db.ExecuteProcedure("sp_Address_Delete", new { Id = id });
    }
}
