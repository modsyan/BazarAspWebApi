using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using Microsoft.AspNetCore.Identity;

namespace Bazar.Core.Entities;

public class User : IdentityUser<Guid>
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public override Guid Id { get; set; }

    [Required, MaxLength(50)] public required string FirstName { get; set; }
    [Required, MaxLength(50)] public required string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<UserRole> Roles { get; set; } = null!;
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }

    public ICollection<Block> BlockedUsers { get; set; } = new List<Block>();
    public ICollection<Block> BlockedByUsers { get; set; } = new List<Block>();

    public ICollection<Product>? Wishlist { get; set; }
    public ICollection<Chat>? Chats { get; set; }
    public ICollection<User>? Following { get; set; }
    public ICollection<User>? Followers { get; set; }
    public ProfilePicture? Picture { get; set; }
    public Guid? CartId { get; set; }
    public Cart? Cart { get; set; }

    [DefaultValue("SYSDATETIME()")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.UserName).IsUnique();
        builder.Property(u => u.Email).IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.UserName).IsRequired();

        // builder
        //     .Property(u => u.Id)
        //     .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder
            .HasOne(user => user.Cart)
            .WithOne(cart => cart.User)
            .HasForeignKey<User>(e => e.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // .UsingEntity(j => j.ToTable("UserBlacklist"));
        builder.HasMany(u => u.Followers)
            .WithMany(u => u.Following);
        // .UsingEntity(j => j.ToTable(""));

        // builder.HasMany(u => u.Wishlist).WithMany(p => p.UsersWishlisted);

        // builder.HasMany<Order>()
        //     .WithOne()
        //     // .HasForeignKey(o=>o.User)
        //     .OnDelete(DeleteBehavior.Cascade);

        // builder.HasIndex(e => e.Email).IsUnique();
        // builder.HasKey(e => e.Email);
        // builder
        //     .Property(m => m.Email)
        //     .IsRequired()
        //     .HasMaxLength(40);
        //
        //
        // builder.HasMany<Review>()
        //     .WithOne(review => review.User)
        //     .HasForeignKey(review => review.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        //
    }
}