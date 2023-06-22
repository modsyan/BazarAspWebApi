using Bazar.Core.Configurations.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations;

public static class EntityConfigurationRegistrar
{
    public static void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
        new CartItemEntityTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
        new ReviewsEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }
}