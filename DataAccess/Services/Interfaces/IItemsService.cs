using DataAccess.Models;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces
{
    public interface IItemsService
    {
        Task DeleteItem(int id);
        Task<ItemDto> GetItem(int id);
        Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName);

        Task<IEnumerable<ItemDto>> GetItemsAll();
        Task<ItemModel> InsertItem(ItemModel model);
        Task<ItemModel> UpdateItem(ItemModel model);
        Task<IEnumerable<ItemDto>> GetNewestItems();
    }
}