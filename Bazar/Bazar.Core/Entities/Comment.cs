using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Comment : BaseModel
{
    public string Content { get; set; } = null!;
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public ICollection<CommentReply> Replies { get; set; }
}

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.Post).WithMany(post => post.Comments)
            .HasForeignKey("PostId").OnDelete(DeleteBehavior.Restrict);
    }
}