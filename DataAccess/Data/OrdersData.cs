using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interfaces
{
    public class OrdersData : IOrdersData
    {
        private readonly IDatabase _db;

        public OrdersData(IDatabase db)
        {
            _db = db;
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            var results = await _db.LoadData<OrderModel, dynamic>("dbo.sp_Order_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertOrder(OrderModel model) =>
            _db.SaveData("dbo.sp_Order_Insert", model);

        public Task UpdateOrder(OrderModel model) =>
            _db.SaveData("dbo.sp_Order_Update", model);

        public Task DeleteOrder(int id) =>
            _db.SaveData("dbo.sp_Order_Delete", new { Id = id });
    }
}
