using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class ReviewsEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        // builder
        //     .Property(p => p.Id)
        //     .HasDefaultValueSql("NEWSEQUENTIALID()");

        // builder
        //     .HasOne<Product>()
        //     .WithMany()
        //     .HasForeignKey(r => r.ProductId)
        //     .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasOne(review => review.Product)
            .WithMany(product => product.Reviews)
            .OnDelete(DeleteBehavior.Restrict);


        // builder.HasOne<Product>()
        //     .WithMany(o => o.Reviews)
        //     .HasForeignKey(o => o.ProductId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne<User>()
        //     .WithMany(o => o.Reviews)
        //     .HasForeignKey(r => r.UserId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}