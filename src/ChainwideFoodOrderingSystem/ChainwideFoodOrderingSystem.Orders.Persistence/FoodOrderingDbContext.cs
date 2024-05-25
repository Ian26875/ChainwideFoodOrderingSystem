using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChainwideFoodOrderingSystem.Orders.Persistence;

public class FoodOrderingDbContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public FoodOrderingDbContext(DbContextOptions<FoodOrderingDbContext> dbContextOptions, 
                                 ILoggerFactory loggerFactory)
        : base(dbContextOptions)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(this._loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }

    public DbSet<Order> Orders { get; }
}