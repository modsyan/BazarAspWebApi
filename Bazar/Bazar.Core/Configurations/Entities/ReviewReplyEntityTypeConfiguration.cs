using Bazar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class ReviewReplyEntityTypeConfiguration : IEntityTypeConfiguration<ReviewReply>
{
    public void Configure(EntityTypeBuilder<ReviewReply> builder)
    {
        builder
            .HasOne(reply => reply.Review)
            .WithMany(review => review.Replies)
            .HasForeignKey("ReviewId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}