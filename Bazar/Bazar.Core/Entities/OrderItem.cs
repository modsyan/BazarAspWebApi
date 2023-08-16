using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class OrderItem : BaseModel
{
    [Required, Range(1, 100)] public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .Property(oi => oi.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey("ProductId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}