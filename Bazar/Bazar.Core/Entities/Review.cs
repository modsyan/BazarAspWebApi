using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Review : BaseModel
{
    protected Review(string content, int rating)
    {
        Content = content;
        Rating = rating;
    }

    [Required] public Product Product { get; set; } = null!;
    [Required] public User User { get; set; } = null!;
    [Required] public string Content { get; set; }
    [Range(minimum: 1, maximum: 5)] public int Rating { get; set; }
    public ICollection<ReviewReply> Replies { get; set; }
}

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
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