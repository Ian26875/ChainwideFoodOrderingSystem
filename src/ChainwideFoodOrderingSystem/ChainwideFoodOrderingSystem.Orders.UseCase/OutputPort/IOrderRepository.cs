using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;

/// <summary>
///     The order repository interface
/// </summary>
/// <seealso cref="IRepository{Order,OrderId}" />
public interface IOrderRepository : IRepository<Order, OrderId>
{
}