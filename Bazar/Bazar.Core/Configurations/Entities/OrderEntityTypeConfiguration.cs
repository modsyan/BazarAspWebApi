using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}