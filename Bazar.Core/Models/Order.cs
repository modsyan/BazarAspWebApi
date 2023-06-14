namespace Bazar.Core.Models;

public class Order
{
    public long Id { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }

    public long AddressId { get; set; }
    public Address Address { get; set; }
    
    

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}