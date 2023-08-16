using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Cart : BaseModel
{
    [Required] public User User { get; set; } = null!;
    public List<CartItem> Items { get; set; } = new();
}

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(c => c.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        
        builder.HasOne(c => c.User).WithOne(u => u.Cart)
            .HasForeignKey("UserId").IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
    }
}
