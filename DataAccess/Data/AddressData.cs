using DataAccess.Data.Interfaces;
using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AddressData : IAddressData
    {
        private readonly IDatabase _db;

        public AddressData(IDatabase db)
        {
            _db = db;
        }

        public async Task<AddressModel?> GetAddress(int id)
        {
            var results = await _db.LoadData<AddressModel, dynamic>("sp_Address_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertAddress(AddressModel model) =>
        _db.SaveData("sp_Address_Insert", model);

        public Task UpdateAddress(AddressModel model) =>
            _db.SaveData("sp_Address_Update", model);

        public Task DeleteAddress(int id) =>
            _db.SaveData("sp_Address_Delete", new { Id = id });


    }
}
