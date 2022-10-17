using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IOrdersService
    {
        Task DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task InsertOrder(OrderModel model);
        Task UpdateOrder(OrderModel model);
    }
}