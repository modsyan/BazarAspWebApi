using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
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
        // builder.HasMany<Order>()
        //     .WithOne(order => order.User)
        //     .HasForeignKey(order => order.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}