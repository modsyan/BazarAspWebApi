using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Block
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public Guid Id { get; set; }

    // public User BlockerUser { get; set; } = null!;
    // public User BlockedUser { get; set; } = null!;

    public Guid BlockerUserId { get; set; }
    public User BlockerUser { get; set; } = null!;
    public Guid BlockedUserId { get; set; }
    public User BlockedUser { get; set; } = null!;

    public DateTime BlockedAt { get; set; } = DateTime.UtcNow;
}

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        // builder.HasOne(b => b.BlockedUser).WithMany()
        //     .HasForeignKey("BlockedUserId").OnDelete(DeleteBehavior.Restrict);
        //
        //
        // builder.HasOne(b => b.BlockerUser).WithMany()
        //     .HasForeignKey("BlockerUserId").OnDelete(DeleteBehavior.Restrict);


        // builder.HasOne(b => b.BlockerUser).WithMany()
        //     .HasForeignKey(b => b.BlockerUserId).OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasOne(b => b.BlockedUser).WithMany()
        //     .HasForeignKey(b => b.BlockedUserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.BlockerUser)
            .WithMany(u => u.BlockedUsers)
            .HasForeignKey(b => b.BlockerUserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.BlockedUser)
            .WithMany(u => u.BlockedByUsers)
            .HasForeignKey(b => b.BlockedUserId).OnDelete(DeleteBehavior.Restrict);
    }
}