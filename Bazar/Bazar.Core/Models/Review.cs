using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Review
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    [Required] public string Content { get; set; }

    [Range(minimum: 1, maximum: 5)] public int Rating { get; set; }

    public virtual ICollection<Review> Replies { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}