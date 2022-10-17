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

        public async Task<OrderModel> GetOrder(int id)
        {
            var results = await _db.LoadData<OrderModel, dynamic>("dbo.sp_Orders_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertOrder(OrderModel model) =>
            _db.SaveData("dbo.sp_Orders_Insert", model);

        public Task UpdateOrder(OrderModel model) =>
            _db.SaveData("dbo.sp_Orders_Update", model);

        public Task DeleteOrder(int id) =>
            _db.SaveData("dbo.sp_Orders_Delete", new { Id = id });
    }
}
