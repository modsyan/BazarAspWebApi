namespace Bazar.Core.Models;

public class CartItem
{
    public required string Id { get; set; }
    
    public required string CartId { get; set; }
    public required Cart Cart { get; set; }
    
    public required string ProductId { get; set; }
    public required Product Product { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}