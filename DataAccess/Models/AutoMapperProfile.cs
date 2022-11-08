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
        CreateMap<AddressRequest, Address>();
        CreateMap<Address, Address>();

        CreateMap<Cart, CartResponse>();
        CreateMap<CartRequest, Cart>();

        CreateMap<CustomerBasicInfo, Customer>().ReverseMap();

        CreateMap<Item, SingleItemResponse>();
        CreateMap<Item, BoughtItem>();
        CreateMap<Item, GroupedItemResponse>();

        CreateMap<OrderRequest, Order>();
        CreateMap<Order, OrderInfo>();
    }
}
