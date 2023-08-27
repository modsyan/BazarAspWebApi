namespace Bazar.Core.DTOs;


public class CreateUpdateCommentRequestDto{

}

public class CommentResponseDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public string Content { get; set; } = null!;
}
