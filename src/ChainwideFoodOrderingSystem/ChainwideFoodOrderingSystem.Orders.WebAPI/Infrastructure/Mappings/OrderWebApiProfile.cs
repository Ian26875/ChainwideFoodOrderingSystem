using AutoMapper;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.PlaceOrder;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.Mappings;

public class OrderWebApiProfile : Profile
{
    public OrderWebApiProfile()
    {
        CreateMap<OrderItemRequest, OrderItemDto>();
        
    }
}