using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Cart
{
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public Guid Id { get; set; }

    public ICollection<CartItem> Items { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}