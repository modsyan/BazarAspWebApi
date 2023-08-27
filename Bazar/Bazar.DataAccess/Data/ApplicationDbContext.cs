using Bazar.Core.Configurations;
using Bazar.Core.Entities;
using Bazar.EF.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bazar.EF.Data;

public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfigurationRegistrar.ApplyConfiguration(modelBuilder);
        // GuidConfiguration.Configure(modelBuilder);
        DefaultValuesConfiguration.SetDefaultValuesTableName(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewReply> ReviewsReplies { get; set; }

    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentReply> CommentReplies { get; set; }

    public DbSet<Block> Blocks { get; set; }

    public DbSet<Faq> Faqs { get; set; }
}