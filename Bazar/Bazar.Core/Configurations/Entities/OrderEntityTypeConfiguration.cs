using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // builder.HasOne<User>()
        //     .WithMany(user => user.Orders)
        //     .HasForeignKey(order => order.UserId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasMany<OrderItem>()
        //     .WithOne(orderItem => orderItem.Order)
        //     .HasForeignKey(orderItem => orderItem.OrderId)
        //     .OnDelete(DeleteBehavior.SetNull);
        //
        // builder.HasOne<Address>()
        //     .WithMany()
        //     .HasForeignKey(order => order.AddressId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}
