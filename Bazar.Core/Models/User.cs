using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// using Microsoft.AspNetCore.Identity;

namespace Bazar.Core.Models;

public class User 
{

    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }

    [Required(ErrorMessage = "User \"FirstName\" is Required, Please try again.")]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "User \"LastName\" is Required, Please try again.")]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "User \"Email\" is Required, Please try again.")]
    [MaxLength(50)]
    public  string? Email { get; set; }

    [Required(ErrorMessage = "User \"PhoneNumber\" is Required, Please try again.")]
    [MaxLength(50)]
    public  string? PhoneNumber { get; set; }

    [Required] public string? Password { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    // ICollection<Role>

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}