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
    public class OrdersService : IOrdersService
    {
        private readonly IDatabase _db;

        public OrdersService(IDatabase db)
        {
            _db = db;
        }

        public async Task<Order> GetOrder(int id)
        {
            var results = await _db.ExecuteProcedure<Order, dynamic>("dbo.sp_Orders_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<Order> InsertOrder(Order model)
        {
            var results = await _db.ExecuteProcedure<Order, Order>("dbo.sp_Orders_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<Order> UpdateOrder(Order model)
        {
            var results = await _db.ExecuteProcedure<Order, Order>("dbo.sp_Orders_Update", model);
            return results.FirstOrDefault();
        }

        public Task DeleteOrder(int id) =>
            _db.ExecuteProcedure("dbo.sp_Orders_Delete", new { Id = id });
    }
}
