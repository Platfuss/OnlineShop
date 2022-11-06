using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

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

    public async Task<ItemDto> GetItemAsync(int id)
    {
        var result = await _db.Items.FindAsync(id);
        var images = await _fileService.ReadAsync(id.ToString(), false);
        var output = _mapper.Map<Item, ItemDto>(result, opt => opt.AfterMap((src, dest) => dest.Images = images));
        return output;
    }

    public async Task<IEnumerable<ItemDto>> GetItemsAllAsync()
    {
        var result = await _db.Items.ToListAsync();
        return await GetItemsWithSingleImageAsync(result);
    }

    public async Task<IEnumerable<ItemDto>> GetItemsInCategoryAsync(string categoryName)
    {
        var result = await _db.Items.Where(x => x.Category == categoryName).ToListAsync();
        return await GetItemsWithSingleImageAsync(result);
    }

    public async Task<IEnumerable<ItemDto>> GetNewestItemsAsync()
    {
        var result = await _db.Items.OrderByDescending(x => x.AddedToShop).ToListAsync();
        return await GetItemsWithSingleImageAsync(result);
    }

    private async Task<List<ItemDto>> GetItemsWithSingleImageAsync(List<Item> items)
    {
        var output = new List<ItemDto>();
        foreach (var model in items)
        {
            var image = await _fileService.ReadAsync(model.Id.ToString(), true);
            var itemEntry = _mapper.Map<Item, ItemDto>(model, opt => opt.AfterMap((src, dest) => dest.Images = image));
            output.Add(itemEntry);
        }
        return output;
    }

    public async Task<Item> InsertItemAsync(Item model)
    {
        _db.Items.Add(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<Item> UpdateItemAsync(Item model)
    {
        _db.Items.Update(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task DeleteItemAsync(int id)
    {
        var item = await _db.Items.FindAsync(id);
        _db.Items.Remove(item);
        await _db.SaveChangesAsync();
    }
}
