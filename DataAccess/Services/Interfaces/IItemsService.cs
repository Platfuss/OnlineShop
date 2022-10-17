using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IItemsService
    {
        Task DeleteItem(int id);
        Task<ItemModel> GetItem(int id);

        Task<IEnumerable<ItemModel>> GetItemsInCategory(string categoryName);

        Task<IEnumerable<ItemModel>> GetItemsAll();
        Task InsertItem(ItemModel model);
        Task UpdateItem(ItemModel model);
    }
}