using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    internal interface IOrdersData
    {
        Task DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task InsertOrder(OrderModel model);
        Task UpdateOrder(OrderModel model);
    }
}