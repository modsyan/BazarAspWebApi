using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class CartItem : BaseModel
{
    [Required] public Cart Cart { get; set; } = null!;
    [Required] public Product Product { get; set; } = null!;
}

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasOne<Product>(item => item.Product).WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }
}