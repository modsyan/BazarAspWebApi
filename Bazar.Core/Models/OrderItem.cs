using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }

    public string? OrderId { get; set; }
    public Order? Order { get; set; }

    public string? ProductId { get; set; }
    public Product? Product { get; set; }

    [Required, Range(1, 100)]
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}