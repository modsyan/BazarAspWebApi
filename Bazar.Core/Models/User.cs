using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

// using Microsoft.AspNetCore.Identity;

namespace Bazar.Core.Models;

public class User
{
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }

    [Required] [MaxLength(50)] public required string FirstName { get; set; }

    [Required] [MaxLength(50)] public required string LastName { get; set; }

    [Required] [MaxLength(50)] public required string Email { get; set; }

    [Required] [MaxLength(50)] public required string PhoneNumber { get; set; }
    [Required] public required string Password { get; set; }
    public DateTime BirthDate { get; set; }

    // ICollection<Role>

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}