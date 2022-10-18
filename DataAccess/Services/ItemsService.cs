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
    public class ItemsService : IItemsService
    {
        private readonly IDatabase _db;

        public ItemsService(IDatabase db)
        {
            _db = db;
        }

        public async Task<ItemModel> GetItem(int id)
        {
            var results = await _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task<IEnumerable<ItemModel>> GetItemsAll() =>
            _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_GetAll", new { });

        public Task<IEnumerable<ItemModel>> GetItemsInCategory(string categoryName) =>
            _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_InCategory", new { Category = categoryName });

        public async Task<ItemModel> InsertItem(ItemModel model)
        {
            var results = await _db.ExecuteProcedure<ItemModel, ItemModel>("dbo.sp_Items_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<ItemModel> UpdateItem(ItemModel model)
        {
            var results = await _db.ExecuteProcedure<ItemModel, ItemModel>("dbo.sp_Items_Update", model);
            return results.FirstOrDefault();
        }
            
        public Task DeleteItem(int id) =>
            _db.ExecuteProcedure("dbo.sp_Items_Delete", new { Id = id });
    }
}
