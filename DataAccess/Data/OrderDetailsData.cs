using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class OrderDetailsData : IOrderDetailsData
    {
        private readonly IDatabase _db;

        public OrderDetailsData(IDatabase db)
        {
            _db = db;
        }

        public async Task<OrderDetailModel?> GetOrderDetail(int id)
        {
            var results = await _db.LoadData<OrderDetailModel, dynamic>("dbo.sp_OrderDetails_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertOrderDetail(OrderDetailModel model) =>
            _db.SaveData("dbo.sp_OrderDetails_Insert", model);

        public Task UpdateOrderDetail(OrderDetailModel model) =>
            _db.SaveData("dbo.sp_OrderDetails_Update", model);

        public Task DeleteOrderDetail(int id) =>
            _db.SaveData("dbo.sp_OrderDetails_Delete", new { Id = id });
    }
}
