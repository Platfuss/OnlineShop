using DataAccess.Models.Database;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface IItemsService
{
    Task DeleteItem(int id);
    Task<ItemDto> GetItem(int id);
    Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName);

    Task<IEnumerable<ItemDto>> GetItemsAll();
    Task<Item> InsertItem(Item model);
    Task<Item> UpdateItem(Item model);
    Task<IEnumerable<ItemDto>> GetNewestItems();
}