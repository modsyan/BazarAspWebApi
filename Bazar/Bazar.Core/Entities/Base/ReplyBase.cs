namespace Bazar.Core.Entities.Base;

public class ReplyBase : BaseModel
{
    public string Content { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
