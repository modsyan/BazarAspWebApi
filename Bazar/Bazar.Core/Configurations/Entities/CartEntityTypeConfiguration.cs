using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        
        builder
            .Property(c=>c.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
        
        // builder.HasMany(c => c.CartItems)
        //     .WithOne(ci => ci.Cart)
        //     .HasForeignKey(ci => ci.CartId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        builder.HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey("UserId")
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
