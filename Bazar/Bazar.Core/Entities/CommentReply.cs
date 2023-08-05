using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class CommentReply : ReplyBase
{
    public Comment Comment { get; set; } = null!;
}
