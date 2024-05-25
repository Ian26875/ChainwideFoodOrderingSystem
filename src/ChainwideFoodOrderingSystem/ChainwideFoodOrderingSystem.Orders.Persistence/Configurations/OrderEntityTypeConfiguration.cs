using ChainwideFoodOrderingSystem.Orders.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChainwideFoodOrderingSystem.Orders.Persistence.Configurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.BuyId).IsRequired();
        builder.Property(o => o.CreatedAt).IsRequired();

        builder.Property(o => o.Status)
            .HasConversion(
                orderStatus => (int)orderStatus,
                intOrderStatus => (OrderStatus)intOrderStatus
            );
        
        builder.Property(o => o.Address)
            .HasConversion
            (
                v => v.ToString(),
                v => Address.FromString(v)
            );

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(nameof(OrderItem.OrderId))
            .OnDelete(DeleteBehavior.Cascade); 

    }
}