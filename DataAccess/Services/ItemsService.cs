using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Converters;

namespace DataAccess.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IDatabase _db;
        private readonly IFileService _fileService;

        public ItemsService(IDatabase db, IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public async Task<ItemDto> GetItem(int id)
        {
            var result = (await _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_GetOne", new { Id = id }))
                .FirstOrDefault();
            var images = await _fileService.Read(id.ToString(), false);
            return ItemConverter.ModelToDto(result, images);
        }
        public async Task<IEnumerable<ItemDto>> GetItemsAll()
        {
            var output = new List<ItemDto>();
            var result = (await _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_GetAll", new { }))
                .ToList();
            foreach (var model in result)
            {
                var images = await _fileService.Read(model.Id.ToString(), true);
                output.Add(ItemConverter.ModelToDto(model, images));
            };

            return output;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName)
        {
            var output = new List<ItemDto>();
            var result = (await _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_InCategory", new { Category = categoryName }))
                .ToList();
            foreach(var model in result)
            {
                var images = await _fileService.Read(model.Id.ToString(), true);
                output.Add(ItemConverter.ModelToDto(model, images));
            }

            return output;
        }

        public async Task<IEnumerable<ItemDto>> GetNewestItems()
        {
            var output = new List<ItemDto>();
            var result = (await _db.ExecuteProcedure<ItemModel, dynamic>("dbo.sp_Items_GetNewests", new { }))
                .ToList();
            foreach (var model in result)
            {
                var images = await _fileService.Read(model.Id.ToString(), true);
                output.Add(ItemConverter.ModelToDto(model, images));
            }

            return output;
        }

        public async Task<ItemModel> InsertItem(ItemModel model)
        {
            var results = (await _db.ExecuteProcedure<ItemModel, ItemModel>("dbo.sp_Items_Insert", model)).FirstOrDefault();

            return results;
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
