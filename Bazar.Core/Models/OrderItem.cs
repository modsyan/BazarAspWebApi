using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }
    
    public required string OrderId { get; set; }
    public required Order Order { get; set; }

    public required string ProductId { get; set; }
    public required Product Product { get; set; }
    
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}