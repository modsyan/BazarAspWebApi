using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class Review : BaseModel
{
    protected Review(string content, int rating)
    {
        Content = content;
        Rating = rating;
    }

    [Required] public Product Product { get; set; } = null!;
    [Required] public User User { get; set; } = null!;
    [Required] public string Content { get; set; }
    [Range(minimum: 1, maximum: 5)] public int Rating { get; set; }
    public ICollection<ReviewReply> Replies { get; set; }
}