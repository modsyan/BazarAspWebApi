// using Bazar.Core.Models;

using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazar.EF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}