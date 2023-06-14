using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Identity;

namespace Bazar.Api.Models;

public class User 
{

    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public Guid Id { get; set; }

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