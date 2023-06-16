namespace Bazar.Core.DTOs;

public class RegisterUserRequestDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Password { get; set; }
    public DateTime BirthDate { get; set; }
}

public class RegisterUserResponseDto
{
    
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
}

public class LoginUserRequestDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class LoginUserResponseDto
{
    public required long Id { get; set; } 
    public required string Email { get; set; }
    public required string Token { get; set; }
    public string? Roles { get; set; }
}

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