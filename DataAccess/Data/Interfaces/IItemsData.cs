using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IItemsData
    {
        Task DeleteItem(int id);
        Task<ItemModel> GetItem(int id);
        Task<IEnumerable<ItemModel>> GetItemsAll();
        Task InsertItem(ItemModel model);
        Task UpdateItem(ItemModel model);
    }
}