namespace Bazar.Core.Models;

public class Cart
{
    public long Id { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}