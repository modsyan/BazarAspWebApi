using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Identity;

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
    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = null!;
    public ICollection<User> Blacklist { get; set; } = null!;
    public ICollection<Product> Wishlist { get; set; } = null!;
    public ICollection<Chat> Chats { get; set; } = null!;
    public ICollection<User> Following { get; set; } = null!;
    public ICollection<User> Followers { get; set; } = null!;
    public ProfilePicture Picture { get; set; } = null!;
    public Guid CartId { get; set; }
    public Cart? Cart { get; set; }

    [DefaultValue("SYSDATETIME()")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
