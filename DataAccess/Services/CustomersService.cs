using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly DataContext _db;

        public CustomersService(DataContext db)
        {
            _db = db;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var result = await _db.Customers.FindAsync(id);
            return result;
        }
        public async Task<IEnumerable<Customer>> GetCustomersAll()
        {
            var result = await _db.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer> InsertCustomer(Customer model)
        {
            _db.Customers.Add(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<Customer> UpdateCustomer(Customer model)
        {
            _db.Customers.Update(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task DeleteCustomer(int id)
        {
            var result = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}
