using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class Comment : BaseModel
{
    public string Content { get; set; } = null!;
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public ICollection<CommentReply> Replies { get; set; }
}