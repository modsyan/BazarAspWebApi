using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;
public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // builder.HasOne<Product>()
        //     .WithMany()
        //     .HasForeignKey(oi => oi.ProductId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne<Order>()
        //     .WithMany(o => o.OrderItems)
        //     .HasForeignKey(oi => oi.OrderId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne<OrderItem>()
        //     .WithMany()
        //     .HasForeignKey(oi => oi.OrderId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
