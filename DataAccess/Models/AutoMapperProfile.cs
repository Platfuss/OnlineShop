using AutoMapper;
using DataAccess.Models.Database;
using DataAccess.Models.Dto;

namespace DataAccess.Models;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Cart, CartResponse>();
        CreateMap<CartRequest, Cart>();
        CreateMap<Item, ItemDto>();
    }
}
