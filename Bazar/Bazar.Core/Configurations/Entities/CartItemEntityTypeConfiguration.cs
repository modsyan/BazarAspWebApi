using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        // builder
        //     .Property(ci=>ci.Id)
        //     .HasDefaultValueSql("NEWSEQUENTIALID()");


        builder
            .HasOne<Product>(p => p.Product)
            .WithMany()
            // .HasForeignKey(ci=>ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}