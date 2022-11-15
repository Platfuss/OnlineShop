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

        CreateMap<CartRequest, Cart>();
        CreateMap<Cart, CartResponse>()
            .ForMember(cr => cr.Name, opt => opt.MapFrom(c => c.Item.Name))
            .ForMember(cr => cr.Price, opt => opt.MapFrom(c => c.Item.Price));

        CreateMap<CustomerBasicInfo, Customer>().ReverseMap();

        CreateMap<Item, SingleItemResponse>();
        CreateMap<Item, BoughtItem>();
        CreateMap<Item, GroupedItemResponse>();

        CreateMap<OrderRequest, Order>();
        CreateMap<Order, OrderInfo>();
    }
}
