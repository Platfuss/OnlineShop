using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Responses;
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

    public async Task<SingleItemResponse> GetItemAsync(int id)
    {
        var result = await _db.Items.FindAsync(id);
        var images = await _fileService.ReadAsync(id.ToString(), false);
        var output = _mapper.Map<Item, SingleItemResponse>(result, opt => opt.AfterMap((src, dest) => dest.Images = images));
        return output;
    }

    public async Task<int> HowManyPagesAsync(int amountPerPage, string category, bool onlyRecommended)
    {
        double quantityOfItems = await _db.Items
            .Where(i => !onlyRecommended || i.Recommended)
            .Where(i => string.IsNullOrEmpty(category)
                || i.Category == category)
            .CountAsync();

        var numberOfPages = (int)Math.Ceiling(quantityOfItems / amountPerPage);

        return numberOfPages;
    }

    public async Task<IEnumerable<GroupedItemResponse>> GetItemsByPagesAsync(int page,
                                                                             int amount,
                                                                             string category,
                                                                             bool onlyRecommended,
                                                                             bool descendingOrderByDate)
    {
        var result = _db.Items
            .Where(i => !onlyRecommended || i.Recommended)
            .Where(i => string.IsNullOrEmpty(category)
                || i.Category == category)
            .Skip(page * amount)
            .Take(amount);

        if (descendingOrderByDate)
        {
            result.OrderByDescending(r => r.AddedToShop);
        }

        var choosenItems = await result.ToListAsync();

        return await GetItemsWithSingleImageAsync(choosenItems);
    }

    private async Task<List<GroupedItemResponse>> GetItemsWithSingleImageAsync(List<Item> items)
    {
        var output = new List<GroupedItemResponse>();
        foreach (var model in items)
        {
            var image = await _fileService.ReadAsync(model.Id.ToString(), true);
            var itemEntry = _mapper.Map<Item, GroupedItemResponse>(model, opt => opt.AfterMap((src, dest) => dest.Image = image.FirstOrDefault()));
            output.Add(itemEntry);
        }
        return output;
    }
}



//public async Task<Item> InsertItemAsync(Item model)
//{
//    _db.Items.Add(model);
//    await _db.SaveChangesAsync();
//    return model;
//}

//public async Task<Item> UpdateItemAsync(Item model)
//{
//    _db.Items.Update(model);
//    await _db.SaveChangesAsync();
//    return model;
//}

//public async Task DeleteItemAsync(int id)
//{
//    var item = await _db.Items.FindAsync(id);
//    _db.Items.Remove(item);
//    await _db.SaveChangesAsync();
//}
