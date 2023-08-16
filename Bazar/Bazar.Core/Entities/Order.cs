using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Order : BaseModel
{
    [Required] public User User { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; }
    [Required] public Address Address { get; set; } = null!;
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}