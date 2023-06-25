using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }
    
    // [Required]
    // public string UserId { get; set; }
    public User User { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } 

    // public string AddressId { get; set; }
    public Address Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}