using DataAccess.Models.Dto.Responses;

namespace DataAccess.Services.Interfaces;

public interface IItemsService
{
    Task<SingleItemResponse> GetItemAsync(int id);
    Task<IEnumerable<GroupedItemResponse>> GetItemsByPagesAsync(int page, int amount, string category, bool onlyRecommended, bool descendingOrderByDate);
    Task<int> HowManyPagesAsync(int amountPerPage, string category, bool onlyRecommended);
    //Task<Item> InsertItemAsync(Item model);
    //Task<Item> UpdateItemAsync(Item model);
}