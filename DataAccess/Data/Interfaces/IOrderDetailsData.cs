using DataAccess.Models;

namespace DataAccess.Data
{
    internal interface IOrderDetailsData
    {
        Task DeleteOrderDetail(int id);
        Task<OrderDetailModel> GetOrderDetail(int id);
        Task InsertOrderDetail(OrderDetailModel model);
        Task UpdateOrderDetail(OrderDetailModel model);
    }
}