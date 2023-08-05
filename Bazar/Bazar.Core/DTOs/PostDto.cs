using Bazar.Core.Entities;

namespace Bazar.Core.DTOs;

public class CreateEditPostRequestDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<byte[]> UploadedImages { get; set; } = null!;
}

public class CreateEditPostResponseDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<byte[]> UploadedImages { get; set; } = null!;
}

public class GetPostResponseDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public List<byte[]> UploadedImages { get; set; } = null!;
   
    //TODO: Return minimal user dto => getUserWithoutDetails()
    public User? User { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}