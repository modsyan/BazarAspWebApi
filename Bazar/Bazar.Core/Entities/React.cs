using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class React : BaseModel
{
    public ReactType ReactType { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }

    public Guid? PostId { get; set; }
    public Post? Post { get; set; }
}

public enum ReactType
{
    Like,
    Love,
    Wonderful,
    Sad,
    Haha
}