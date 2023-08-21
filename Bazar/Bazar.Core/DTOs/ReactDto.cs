using Bazar.Core.Entities;

namespace Bazar.Core.DTOs;

public class ReactDto
{
    public Guid Id { get; set; }
    public UserResponseDto User { get; set; } = null!;
    public ReactType ReactType { get; set; }
}