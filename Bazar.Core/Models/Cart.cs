using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Cart
{
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public required string Id { get; set; }
    public List<CartItem>? CartItems { get; set; }
    
    public required string UserId { get; set; }
    public required User User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}