using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IItemsService
    {
        Task DeleteItem(int id);
        Task<ItemModel> GetItem(int id);

        Task<IEnumerable<ItemModel>> GetItemsInCategory(string categoryName);

        Task<IEnumerable<ItemModel>> GetItemsAll();
        Task<ItemModel> InsertItem(ItemModel model);
        Task<ItemModel> UpdateItem(ItemModel model);
    }
}