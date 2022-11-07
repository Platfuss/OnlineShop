using AutoMapper;
using DataAccess.Models.Database;
using DataAccess.Models.Dto;
using DataAccess.Models.Dto.Helpers;

namespace DataAccess.Models;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Cart, CartResponse>();
        CreateMap<CartRequest, Cart>();
        CreateMap<Item, ItemDto>();
        CreateMap<OrderRequest, Order>();
        CreateMap<Item, BoughtItem>();
        CreateMap<Order, OrderInfo>();
    }
}
