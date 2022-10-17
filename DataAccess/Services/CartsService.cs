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
    public class CartsService : ICartsService
    {
        private readonly IDatabase _db;

        public CartsService(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CartModel>> GetUserCart(int customerId) => 
            await _db.LoadData<CartModel, dynamic>("dbo.sp_Carts_GetUserCart", new { CustomerId = customerId });

        public Task InsertIntoCart(CartModel model) =>
            _db.SaveData("dbo.sp_Carts_Insert", model);

        public Task UpdateCart(CartModel model) =>
            _db.SaveData("dbo_Carts_Update", model);

        public Task DeleteFromCart(int customerId, int itemId) =>
            _db.SaveData("dbo.sp_Carts_Delete", new { CustomerId = customerId, ItemId = itemId });

    }
}
