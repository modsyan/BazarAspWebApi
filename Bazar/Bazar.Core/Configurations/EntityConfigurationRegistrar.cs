using Bazar.Core.Configurations.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations;

public static class EntityConfigurationRegistrar
{
    public static void ApplyConfiguration(ModelBuilder modelBuilder)
    {
        // new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<Address>());
        //
        // new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
        new CartItemEntityTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
        //
        // new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        //
        // new FaqEntityTypeConfiguration().Configure(modelBuilder.Entity<Faq>());
        //
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        // new OrderItemEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        //
        // new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        // new ProductImageEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductImage>());
        //
        new ReviewsEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }
}