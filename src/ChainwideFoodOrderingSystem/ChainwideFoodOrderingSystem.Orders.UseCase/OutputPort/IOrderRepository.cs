using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;

namespace ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;

/// <summary>
///     The order repository interface
/// </summary>
/// <seealso cref="IRepository{Order,OrderId}" />
public interface IOrderRepository : IRepository<Order, OrderId>
{
}