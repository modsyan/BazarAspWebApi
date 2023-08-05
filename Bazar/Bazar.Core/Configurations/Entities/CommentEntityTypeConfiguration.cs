using Bazar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.Post)
            .WithMany(post => post.Comments)
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}