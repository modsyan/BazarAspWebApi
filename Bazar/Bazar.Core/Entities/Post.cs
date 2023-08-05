using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class Post : BaseModel
{
    public Post()
    {
        Images = new List<PostImage>();
        Comments = new List<Comment>();
    }

    [Required] public string Title { get; set; } = null!;
    [Required] public string Content { get; set; } = null!;
    [Required] public ICollection<PostImage> Images { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; }

    [Required] public ICollection<Comment> Comments { get; set; }
    // [Required] public ICollection<React>  Reacts { get; set; }
}