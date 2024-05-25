using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using Microsoft.EntityFrameworkCore;

namespace ChainwideFoodOrderingSystem.Orders.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly FoodOrderingDbContext _db;

    public OrderRepository(FoodOrderingDbContext db)
    {
        _db = db;
    }

    public async Task<Order?> FindAsync(OrderId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        var order = await _db.FindAsync<Order>(id);

        return order;
    }

    public async Task<Order> SaveAsync(Order aggregateRoot)
    {
        ArgumentNullException.ThrowIfNull(aggregateRoot);

        var entityEntry = await _db.Orders.AddAsync(aggregateRoot);
        await _db.SaveChangesAsync();  

        return entityEntry.Entity;
    }

    public async Task<Order> ModifyAsync(Order aggregateRoot)
    {
        
        ArgumentNullException.ThrowIfNull(aggregateRoot)
            ;
        // 检查数据库中是否已存在该订单
        var existingOrder = await _db.Orders.FindAsync(aggregateRoot.Id);
        if (existingOrder == null)
        {
            throw new InvalidOperationException("Cannot modify a non-existing order.");
        }
        
        _db.Entry(existingOrder).CurrentValues.SetValues(aggregateRoot);
        
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new Exception("A concurrency error occurred.", ex);
        }

        return existingOrder;
    }
}