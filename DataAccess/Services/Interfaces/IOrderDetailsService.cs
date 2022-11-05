using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IOrderDetailsService
{
    Task DeleteOrderDetail(int id);
    Task<OrderDetail> GetOrderDetail(int id);
    Task<OrderDetail> InsertOrderDetail(OrderDetail model);
    Task<OrderDetail> UpdateOrderDetail(OrderDetail model);
}