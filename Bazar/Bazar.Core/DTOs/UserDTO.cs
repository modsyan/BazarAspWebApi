using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Bazar.Core.DTOs;

public class UpdateUserRequestDto
{
}

public class UpdateUserResponseDto
{
}

public class RemoveUserRequestDto
{
}

public class RemoveUserResponseDto
{
}

public class GetUserMinimalResponseDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public byte[] ProfilePicture { get; set; } = null!;
}

public class GetUserDetailResponseDto
{
}