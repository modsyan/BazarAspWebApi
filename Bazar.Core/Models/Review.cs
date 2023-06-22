
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Review
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }

    [ForeignKey("ProductId")]
    public  string ProductId { get; set; }
    public  Product Product { get; set; }
    
    [ForeignKey("UserId")]
    public  string UserId { get; set; }
    public  User User { get; set; }
    
    public required string Content { get; set; }
    
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public required int Rating { get; set; }
    public virtual HashSet<Review>? Replies { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}