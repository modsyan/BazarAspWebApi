using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.UserName).IsUnique();
        builder.Property(u => u.Email).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.UserName).IsRequired();

        // builder
        //     .Property(u => u.Id)
        //     .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder
            .HasOne(user => user.Cart)
            .WithOne(cart => cart.User)
            // .HasForeignKey("CartId")
            .HasForeignKey<User>(e=>e.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // builder.HasMany<Order>()
        //     .WithOne()
        //     // .HasForeignKey(o=>o.User)
        //     .OnDelete(DeleteBehavior.Cascade);

        // builder.HasIndex(e => e.Email).IsUnique();
        // builder.HasKey(e => e.Email);
        // builder
        //     .Property(m => m.Email)
        //     .IsRequired()
        //     .HasMaxLength(40);
        //
        //
        // builder.HasMany<Review>()
        //     .WithOne(review => review.User)
        //     .HasForeignKey(review => review.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        //
    }
}