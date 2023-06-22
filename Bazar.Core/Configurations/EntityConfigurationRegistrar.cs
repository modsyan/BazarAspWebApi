using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations;

public class EntityConfigurationRegistrar: IEntityTypeConfiguration<TEntity>
{
    public void Configure(EntityTypeBuilder<EntityTypeBuilder> builder)
    {
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
        new CartItemEntityTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
        new ReviewsEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
    }
}