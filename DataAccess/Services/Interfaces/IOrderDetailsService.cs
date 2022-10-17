using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IOrderDetailsService
    {
        Task DeleteOrderDetail(int id);
        Task<OrderDetailModel> GetOrderDetail(int id);
        Task InsertOrderDetail(OrderDetailModel model);
        Task UpdateOrderDetail(OrderDetailModel model);
    }
}