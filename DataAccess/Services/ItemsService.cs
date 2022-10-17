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
            var results = await _db.LoadData<ItemModel, dynamic>("dbo.sp_Items_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task<IEnumerable<ItemModel>> GetItemsAll() =>
            _db.LoadData<ItemModel, dynamic>("dbo.sp_Items_GetAll", new { });

        public Task<IEnumerable<ItemModel>> GetItemsInCategory(string categoryName) =>
            _db.LoadData<ItemModel, dynamic>("dbo.sp_Items_InCategory", new { Category = categoryName });

        public Task InsertItem(ItemModel model) =>
            _db.SaveData("dbo.sp_Items_Insert", model);

        public Task UpdateItem(ItemModel model) =>
            _db.SaveData("dbo.sp_Items_Update", model);

        public Task DeleteItem(int id) =>
            _db.SaveData("dbo.sp_Items_Delete", new { Id = id });
    }
}
