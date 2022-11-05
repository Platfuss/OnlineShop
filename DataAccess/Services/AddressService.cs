using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
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
        private readonly DataContext _db;

        public AddressService(DataContext db)
        {
            _db = db;
        }

        public async Task<Address> GetAddress(int id)
        {
            var address = await _db.Addresses.FindAsync(id);
            return address;
        }

        public async Task<Address> InsertAddress(Address model)
        {
            _db.Addresses.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Address> UpdateAddress(Address model)
        {
            _db.Addresses.Update(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task DeleteAddress(int id)
        {
            var address = await _db.Addresses.FindAsync(id);
             _db.Addresses.Remove(address);
            await _db.SaveChangesAsync();
        }
    }
}
