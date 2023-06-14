namespace Bazar.Core.Models;

public class OrderItem
{
    public long Id { get; set; }
    public long OrderId { get; set; }

    public long userId { get; set; }
    public User User { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}