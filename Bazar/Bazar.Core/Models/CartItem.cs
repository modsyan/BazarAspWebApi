using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class CartItem
{
    public Guid Id { get; set; }

    [Required] public Guid CartId { get; set; }
    [Required] public Cart Cart { get; set; }

    [Required] public Guid ProductId { get; set; }
    [Required] public Product Product { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}