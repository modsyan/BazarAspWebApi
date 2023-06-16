// using Bazar.Core.Models;

using Bazar.Core.Configurations;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazar.EF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        // new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}