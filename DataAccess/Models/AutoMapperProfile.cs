using AutoMapper;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Helpers;
using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;

namespace DataAccess.Models;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        CreateMap<Cart, CartResponse>();
        CreateMap<CartRequest, Cart>();
        CreateMap<Item, SingleItemResponse>();
        CreateMap<OrderRequest, Order>();
        CreateMap<Item, BoughtItem>();
        CreateMap<Order, OrderInfo>();
        CreateMap<CustomerBasicInfo, Customer>().ReverseMap();
        CreateMap<AddressRequest, Address>();
        CreateMap<Address, Address>();
    }
}
