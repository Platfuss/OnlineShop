using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IDatabase _db;

        public CustomersService(IDatabase db)
        {
            _db = db;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var results = await _db.ExecuteProcedure<Customer, dynamic>("dbo.sp_Customers_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task<IEnumerable<Customer>> GetCustomersAll() =>
            _db.ExecuteProcedure<Customer, dynamic>("dbo.sp_Customers_GetAll", new { });

        public async Task<Customer> InsertCustomer(Customer model)
        {
            var results = await _db.ExecuteProcedure<Customer, Customer>("dbo.sp_Customers_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<Customer> UpdateCustomer(Customer model)
        {
            var results = await _db.ExecuteProcedure<Customer, Customer>("dbo.sp_Customers_Update", model);
            return results.FirstOrDefault();
        }

        public Task DeleteCustomer(int id) =>
            _db.ExecuteProcedure("dbo.sp_Customers_Delete", new { Id = id });
    }
}
