using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IOrderDetailsService
    {
        Task DeleteOrderDetail(int id);
        Task<OrderDetailModel> GetOrderDetail(int id);
        Task<OrderDetailModel> InsertOrderDetail(OrderDetailModel model);
        Task<OrderDetailModel> UpdateOrderDetail(OrderDetailModel model);
    }
}