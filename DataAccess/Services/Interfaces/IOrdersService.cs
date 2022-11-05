using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces
{
    public interface IOrdersService
    {
        Task DeleteOrder(int id);
        Task<Order> GetOrder(int id);
        Task<Order> InsertOrder(Order model);
        Task<Order> UpdateOrder(Order model);
    }
}