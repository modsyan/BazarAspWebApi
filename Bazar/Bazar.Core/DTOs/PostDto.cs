using Bazar.Core.Entities;

namespace Bazar.Core.DTOs;

public class CreateEditPostRequestDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid ProductId { get; set; }
    public List<byte[]> UploadedImages { get; set; } = null!;
}

public class PostResponseDto
{
    public Guid Id { get; set; }
    public UserResponseDto User { get; set; } = null!;
    public ProductResponseDto Product { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<byte[]> UploadedImages { get; set; } = null!;

    public List<Comment>? Comments { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class PostDetailResponseDto: PostResponseDto
{
}