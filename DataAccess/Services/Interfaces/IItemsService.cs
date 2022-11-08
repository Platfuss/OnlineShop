using DataAccess.Models.Database;
using DataAccess.Models.Dto.Responses;

namespace DataAccess.Services.Interfaces;

public interface IItemsService
{
    Task<SingleItemResponse> GetItemAsync(int id);
    Task<IEnumerable<SingleItemResponse>> GetItemsAllAsync();
    Task<IEnumerable<SingleItemResponse>> GetItemsInCategoryAsync(string categoryName);
    Task<IEnumerable<SingleItemResponse>> GetNewestItemsAsync();
    Task<Item> InsertItemAsync(Item model);
    Task<Item> UpdateItemAsync(Item model);
}