using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IOrdersService
    {
        Task DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task<OrderModel> InsertOrder(OrderModel model);
        Task<OrderModel> UpdateOrder(OrderModel model);
    }
}