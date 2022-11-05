using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models.Database;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Services
{
    public class ItemsService : IItemsService
    {
        private readonly DataContext _db;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ItemsService(DataContext db, IFileService fileService, IMapper mapper)
        {
            _db = db;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<ItemDto> GetItem(int id)
        {
            var result = await _db.Items.FindAsync(id);
            var images = await _fileService.Read(id.ToString(), false);
            var output = _mapper.Map<Item, ItemDto>(result, opt => opt.AfterMap((src, dest) => dest.Images = images));
            return output;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAll()
        {
            var result = await _db.Items.ToListAsync();
            return await GetItemsWithSingleImage(result);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName)
        {
            var result = await _db.Items.Where(x => x.Category == categoryName).ToListAsync();
            return await GetItemsWithSingleImage(result);
        }

        public async Task<IEnumerable<ItemDto>> GetNewestItems()
        {
            var result = await _db.Items.OrderByDescending(x => x.AddedToShop).ToListAsync();
            return await GetItemsWithSingleImage(result);
        }

        private async Task<List<ItemDto>> GetItemsWithSingleImage(List<Item> items)
        {
            var output = new List<ItemDto>();
            foreach (var model in items)
            {
                var image = await _fileService.Read(model.Id.ToString(), true);
                var itemEntry = _mapper.Map<Item, ItemDto>(model, opt => opt.AfterMap((src, dest) => dest.Images = image));
                output.Add(itemEntry);
            }
            return output;
        }

        public async Task<Item> InsertItem(Item model)
        {
            _db.Items.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Item> UpdateItem(Item model)
        {
            _db.Items.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
            
        public async Task DeleteItem(int id)
        {
            var item = await _db.Items.FindAsync(id);
            _db.Items.Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
