using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class CommentReply : ReplyBase
{
    public Comment Comment { get; set; } = null!;
}

public class CommentReplyConfiguration : IEntityTypeConfiguration<CommentReply>
{
    public void Configure(EntityTypeBuilder<CommentReply> builder)
    {
        builder.HasOne(reply => reply.Comment).WithMany(comment => comment.Replies)
            .HasForeignKey("CommentId").OnDelete(DeleteBehavior.Restrict);
    }
}