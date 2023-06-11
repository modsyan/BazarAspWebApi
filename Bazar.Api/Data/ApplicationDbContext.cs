using System.Collections.Immutable;
using Bazar.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
}