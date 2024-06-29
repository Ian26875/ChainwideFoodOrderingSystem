using AutoMapper;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Models.CreateOrder;

namespace ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.Mappings;

public class OrderWebApiProfile : Profile
{
    public OrderWebApiProfile()
    {
        CreateMap<OrderItemRequest, OrderItemDto>();
        
    }
}