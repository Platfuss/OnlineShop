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

        public async Task<CustomerModel> GetCustomer(int id)
        {
            var results = await _db.LoadData<CustomerModel, dynamic>("dbo.sp_Customers_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task<IEnumerable<CustomerModel>> GetCustomersAll() =>
            _db.LoadData<CustomerModel, dynamic>("dbo.sp_Customers_GetAll", new { });

        public Task InsertCustomer(CustomerModel model) =>
            _db.SaveData("dbo.sp_Customers_Insert", model);

        public Task UpdateCustomer(CustomerModel model) =>
            _db.SaveData("dbo.sp_Customers_Update", model);

        public Task DeleteCustomer(int id) =>
            _db.SaveData("dbo.sp_Customers_Delete", new { Id = id });
    }
}
