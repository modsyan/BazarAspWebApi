using Bazar.Core.Configurations;
using Bazar.Core.Configurations.Entities;
using Bazar.Core.Constants;
using Bazar.Core.Models;
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
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> Cart { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<Faq> Faqs { get; set; }
}