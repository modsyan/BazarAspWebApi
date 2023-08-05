using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .Property(oi => oi.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey("ProductId")
            .OnDelete(DeleteBehavior.Restrict);

        // builder
        //     .HasOne<Product>()
        //     .WithOne()
        //     .HasForeignKey<OrderItem>("ProductId")
        //     .OnDelete(DeleteBehavior.Restrict);

        // builder.HasOne<Order>()
        //     .WithMany(o => o.OrderItems)
        //     // .HasForeignKey(oi => oi.OrderId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}