using DataAccess.Models.Database;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface IItemsService
{
    Task<ItemDto> GetItemAsync(int id);
    Task<IEnumerable<ItemDto>> GetItemsAllAsync();
    Task<IEnumerable<ItemDto>> GetItemsInCategoryAsync(string categoryName);
    Task<IEnumerable<ItemDto>> GetNewestItemsAsync();
    Task<Item> InsertItemAsync(Item model);
    Task<Item> UpdateItemAsync(Item model);
    Task DeleteItemAsync(int id);
}