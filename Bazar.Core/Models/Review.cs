
namespace Bazar.Core.Models;

public class Review
{
    public Guid Id { get; set; }

    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
    
    public string Content { get; set; }
    public int? Rating { get; set; } 
    
    public virtual HashSet<Review> Replies { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}