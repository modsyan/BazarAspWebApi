using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class ReviewReply : ReplyBase
{
    public Guid ReviewId { get; set; }
    public Review Review { get; set; } = null!;
}

public class ReviewReplyConfiguration : IEntityTypeConfiguration<ReviewReply>
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
