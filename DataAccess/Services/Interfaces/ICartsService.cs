﻿using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface ICartsService
    {
        Task DeleteFromCart(int userId, int itemId);
        Task<CartModel> GetUserCart(int id);
        Task InsertIntoCart(CartModel model);
    }
}