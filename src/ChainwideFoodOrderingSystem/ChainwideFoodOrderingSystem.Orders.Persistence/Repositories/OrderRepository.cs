using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using Microsoft.EntityFrameworkCore;

namespace ChainwideFoodOrderingSystem.Orders.Persistence.Repositories;

/// <summary>
/// The order repository class
/// </summary>
/// <seealso cref="IOrderRepository"/>
public class OrderRepository : IOrderRepository
{
    /// <summary>
    /// The db
    /// </summary>
    private readonly FoodOrderingDbContext _db;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderRepository"/> class
    /// </summary>
    /// <param name="db">The db</param>
    public OrderRepository(FoodOrderingDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Finds the id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>The order</returns>
    public async Task<Order?> FindAsync(OrderId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        var order = await _db.FindAsync<Order>(id);

        return order;
    }

    /// <summary>
    /// Saves the aggregate root
    /// </summary>
    /// <param name="aggregateRoot">The aggregate root</param>
    /// <returns>A task containing the order</returns>
    public async Task<Order> SaveAsync(Order aggregateRoot)
    {
        ArgumentNullException.ThrowIfNull(aggregateRoot);

        var entityEntry = await _db.Orders.AddAsync(aggregateRoot);
        await _db.SaveChangesAsync();  

        return entityEntry.Entity;
    }

    /// <summary>
    /// Modifies the aggregate root
    /// </summary>
    /// <param name="aggregateRoot">The aggregate root</param>
    /// <exception cref="Exception">A concurrency error occurred. </exception>
    /// <exception cref="InvalidOperationException">Cannot modify a non-existing order.</exception>
    /// <returns>The existing order</returns>
    public async Task<Order> ModifyAsync(Order aggregateRoot)
    {
        
        ArgumentNullException.ThrowIfNull(aggregateRoot);
        var existingOrder = await _db.Orders.FindAsync(aggregateRoot.Id);
        if (existingOrder is null)
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