using System.Runtime.CompilerServices;
using Bazar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class CommentReplyEntityTypeConfiguration: IEntityTypeConfiguration<CommentReply>
{
    public void Configure(EntityTypeBuilder<CommentReply> builder)
    {
        builder
            .HasOne(reply => reply.Comment)
            .WithMany(comment => comment.Replies)
            .HasForeignKey("CommentId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}