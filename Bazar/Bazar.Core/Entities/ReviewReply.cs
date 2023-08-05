using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class ReviewReply : ReplyBase
{
    public Guid ReviewId { get; set; }
    public Review Review { get; set; } = null!;
}
