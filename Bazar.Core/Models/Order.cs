using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }
    
    public required string UserId { get; set; }
    public required User User { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } 

    public required string AddressId { get; set; }
    public required Address Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}