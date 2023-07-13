using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

// using Microsoft.AspNetCore.Identity;

namespace Bazar.Core.Models;

public class User : IdentityUser<Guid>
{
    [Required, MaxLength(50)] public required string FirstName { get; set; }
    [Required, MaxLength(50)] public required string LastName { get; set; }

    public List<UserRole>? Roles { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<User>? Blacklist { get; set; }

    public ICollection<Product>? Wishlist { get; set; }
    // public ICollection<Chat>? Chats { get; set; }

    // To Two Tables
    public ICollection<User>? Following { get; set; }
    public ICollection<User>? Followers { get; set; }
        
    public Cart Cart { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}