using DataAccess.Models.Database;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface IOrdersService
{
    Task DeleteOrderAsync(int id);
    Task<OrderInfo> GetOrderAsync(int id);
    Task<Order> InsertOrderAsync(OrderRequest request);
    Task<Order> UpdateOrderAsync(Order model);
}