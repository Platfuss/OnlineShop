using DataAccess.DatabaseAccess;
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
        private readonly DataContext _context;

        public AddressService(DataContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            return address;
        }

        public async Task<Address> InsertAddress(Address model)
        {
            _context.Addresses.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Address> UpdateAddress(Address model)
        {
            var address = (await _context.Addresses.FindAsync(model.Id));

            address.Street = model.Street;
            address.City = model.City;
            address.PostalCode = model.PostalCode;

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
             _context.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
