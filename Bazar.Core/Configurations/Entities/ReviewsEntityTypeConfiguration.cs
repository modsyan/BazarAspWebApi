using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class ReviewsEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasOne<Product>()
            .WithMany(o => o.Reviews).HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>().WithMany(u=> u.Reviews).HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}