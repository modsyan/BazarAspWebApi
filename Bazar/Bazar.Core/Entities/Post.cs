using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Post : BaseModel
{
    [Required] public Guid ProductId { get; set; }
    [Required] public Product Product { get; set; } = null!;

    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; } = null!;
    [Required] public string Title { get; set; } = null!;
    [Required] public string Content { get; set; } = null!;
    [Required] public ICollection<PostImage> Images { get; set; } = null!;
    [Required] public ICollection<Comment>? Comments { get; set; }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasOne(p => p.Product).WithMany(p => p.Posts)
            .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}